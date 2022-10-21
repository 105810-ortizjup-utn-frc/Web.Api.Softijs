using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using Web.Api.Softijs.Commands;
using Web.Api.Softijs.DataContext;
using Web.Api.Softijs.Models;
using Web.Api.Softijs.Results;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Web.Api.Softijs.Services
{
    public class ServicioLogin : IServicioLogin
    {
        private readonly IServicioLogin loginServicio;
        private readonly IConfiguration config;
        private readonly SoftijsDevContext context;
        public ServicioLogin(SoftijsDevContext _context, IServicioLogin _loginServicio, IConfiguration _config)
        {
            this.context = _context;
            this.loginServicio = _loginServicio;
            this.config = _config;
        }
        public List<Usuario> GetUsuarios()
        {
            return context.Usuarios.AsNoTracking().ToList();
        }

        public async Task<ActionResult<ResultadoBase>> Login([FromBody] ComandoLogin comando)
        {
            var resultado = new ResultadoBase();
            try
            {

                byte[] ePass = GetHash(comando.Contrasenia);
                var activo = await context.Usuarios.FirstOrDefaultAsync(c => c.Activo);

                var emailPass = await context.Usuarios.FirstOrDefaultAsync(c => c.Email == comando.Email && c.HashContrasenia == ePass);

                if (emailPass != null)
                {
                    if (emailPass.Activo && activo != null)
                    {
                        resultado.Ok = true;
                        resultado.CodigoEstado = 200;
                        resultado.Error = "Es activo y valido";
                        return resultado;
                    }
                    else
                    {
                        resultado.Ok = false;
                        resultado.CodigoEstado = 400;
                        resultado.Error = ("El email no esta activo");
                        return resultado;
                    }
                }
                else
                {
                    resultado.Ok = false;
                    resultado.CodigoEstado = 400;
                    resultado.Error = ("El email o contraseña no existe");
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                resultado.Ok = false;
                resultado.CodigoEstado = 400;
                resultado.Error = "Error al ingresar al login";
                return resultado;
            }
        }



        //[HttpPost("login")]
        //public async Task<IActionResult> LoginUser(ComandoLogin userForLoginDto)
        //{
        //    var userFromRepo = await loginServicio.LoginUser(userForLoginDto.Email.ToLower(), userForLoginDto.Contrasenia);

        //    if (userFromRepo == null)
        //        return Unauthorized();

        //    var claims = new[]
        //    {
        //        new Claim(ClaimTypes.NameIdentifier, userFromRepo.IdUsuario.ToString()),
        //        new Claim(ClaimTypes.Name, userFromRepo.Email)
        //    };

        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetSection("AppSettings:Token").Value));

        //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(claims),
        //        Expires = DateTime.Now.AddDays(double.Parse(config.GetSection("AppSettings:Expires").Value)),
        //        SigningCredentials = creds
        //    };

        //    var tokenHandler = new JwtSecurityTokenHandler();

        //    var token = tokenHandler.CreateToken(tokenDescriptor);

        //    var user = ((ListadoUsuarioDto)userFromRepo);

        //    return Ok(new
        //    {
        //        token = tokenHandler.WriteToken(token),
        //        user
        //    });
        //}


        private byte[] GetHash(string key)
        {
            var bytes = Encoding.UTF8.GetBytes(key);
            return new SHA256Managed().ComputeHash(bytes);
        }

    }

}
