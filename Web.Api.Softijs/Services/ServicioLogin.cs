using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Web.Api.Softijs.Commands;
using Web.Api.Softijs.DataContext;
using Web.Api.Softijs.Models;
using Web.Api.Softijs.Results.Login;
using System.Security.Cryptography;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Web.Api.Softijs.Services
{
    public class ServicioLogin : IServicioLogin
    {
        private readonly SoftijsDevContext context;
        public ServicioLogin(SoftijsDevContext _context)
        {
            this.context = _context;
        }
        public List<Usuario> GetUsuarios()
        {
            return context.Usuarios.AsNoTracking().ToList();
        }

        public async Task<ActionResult<ResultadoLogin>> Login([FromBody] ComandoLogin comando)
        {
            var resultado = new ResultadoLogin();
            try
            {

                byte[] ePass = GetHash(comando.Contrasenia);
              


                var activo = await context.Usuarios.FirstOrDefaultAsync(c => c.Activo);

                var emailPass = await context.Usuarios.FirstOrDefaultAsync(c => c.Email == comando.Email && c.HashContrasenia == ePass);
                if (emailPass != null)
                {
                   
                    if (emailPass.Activo && activo != null)
                    {
                        resultado.resultadoLogin = true;
                        resultado.Ok = true;
                        resultado.CodigoEstado = 200;
                        resultado.Error = "Es activo y valido";
                        return resultado;
                    }

                    else
                    {
                        resultado.resultadoLogin = false;
                        resultado.Ok = false;
                        resultado.CodigoEstado = 400;
                        resultado.Error = ("El email no esta activo");
                        return resultado;
                    }
                }
                else
                {
                    resultado.resultadoLogin = false;
                    resultado.Ok = false;
                    resultado.CodigoEstado = 400;
                    resultado.Error = ("El email o contraseña no existe");
                    return resultado;
                }

            }
            catch (Exception ex)
            {
                resultado.resultadoLogin = false;
                resultado.Ok = false;
                resultado.CodigoEstado = 400;
                resultado.Error = "Error al ingresar al login";
                return resultado;
            }
        }

        private byte[] GetHash(string key)
        {
            var bytes = Encoding.UTF8.GetBytes(key);
            return new SHA256Managed().ComputeHash(bytes);
        }
    }
}
