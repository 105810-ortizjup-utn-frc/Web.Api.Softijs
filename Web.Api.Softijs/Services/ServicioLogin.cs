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

        //public void Agregar()
        //{
        //    try
        //    {
        //        var usuario = new Usuario { Email = "test@test.com", HashContrasenia = this.GetHash("Test123465*"), Activo = true, IdTipoUsuario = 1 };
        //        var usuarioCheck = (this.context.Usuarios.FirstOrDefault(x => x.Email == usuario.Email));
        //        if (usuarioCheck != null)
        //        {
        //            this.context.Remove(usuarioCheck);
        //            //await this.context.SaveChangesAsync("Lucio");

        //        }
        //        this.context.Add(usuario);
        //        this.context.SaveChanges("Lucio");
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }


        //}

        public async Task<ActionResult<ResultadoLogin>> Login([FromBody] ComandoLogin comando)
        {
            var resultado = new ResultadoLogin();
            try
            {

                byte[] ePass = GetHash(comando.Contrasenia);
                var usuario = await context.Usuarios.FirstOrDefaultAsync(c => c.Activo && c.Email == comando.Email && c.HashContrasenia == ePass);
                if (usuario != null)
                {
                    resultado.resultadoLogin = true;
                    resultado.Ok = true;
                    resultado.CodigoEstado = 200;
                    return resultado;
                }
                resultado.Error = ("Email o password incorrecto");
                return resultado;


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
