using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
//using System.Web.Mvc;
using Web.Api.Softijs.Commands;
using Web.Api.Softijs.DataContext;
using Web.Api.Softijs.Models;
using Web.Api.Softijs.Results;

namespace Web.Api.Softijs.Services
{
    public class ServicioLogin : IServicioLogin
    {
        private readonly IConfiguration config;
        private readonly SoftijsDevContext context;
        public ServicioLogin(SoftijsDevContext _context, IConfiguration _config)
        {
            this.context = _context;
            this.config = _config;
        }
        public async Task<List<Usuario>> GetUsuarios()
        {
            return await context.Usuarios.AsNoTracking().ToListAsync();
        }

        public async Task<ComandoLogin> Login([FromBody] ComandoLogin comando)
        {
            ComandoLogin emailPass = new ComandoLogin();

            try
            {
                byte[] ePass = GetHash(comando.Contrasenia);
                var activo = await context.Usuarios.FirstOrDefaultAsync(c => c.Activo);

                emailPass = await context.Usuarios
                    .Include(x => x.UsuariosRoles)
                    .ThenInclude(x => x.IdRolNavigation)
                    .FirstOrDefaultAsync(c => c.Email == comando.Email && c.HashContrasenia == ePass) ??  new ComandoLogin();

                if (emailPass != null)
                {
                    if (emailPass.Activo && activo != null)
                    {
                        emailPass.Ok = true;
                        emailPass.CodigoEstado = 200;
                        emailPass.Error = "Es activo y valido";
                        return emailPass;
                    }
                    else
                    {
                        emailPass.Ok = false;
                        emailPass.CodigoEstado = 400;
                        emailPass.Error = ("El email no esta activo");
                        return emailPass;
                    }
                }
                else
                {
                    emailPass.Ok = false;
                    emailPass.CodigoEstado = 400;
                    emailPass.Error = ("El email o contraseña no existe");
                    return emailPass;
                }
            }
            catch (Exception ex)
            {
                emailPass.Ok = false;
                emailPass.CodigoEstado = 400;
                emailPass.Error = ex.Message;
                return emailPass;
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



