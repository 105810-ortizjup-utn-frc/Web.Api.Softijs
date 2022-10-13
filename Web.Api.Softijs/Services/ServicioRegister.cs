using System.Text;
using System.Security.Cryptography;
using Web.Api.Softijs.Results;
using Web.Api.Softijs.Models;
using Web.Api.Softijs.DataContext;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Web.Api.Softijs.Commands;

namespace Web.Api.Softijs.Services

{
    public class ServicioRegister : IServicioRegister
    {
        private readonly SoftijsDevContext context;
        public ServicioRegister(SoftijsDevContext _context) { this.context = _context; }
        public async Task<ResultadoBase> PostRegister(Usuario  u, ComandoRegister comando)
        {
            ResultadoBase resultado = new ResultadoBase();
            
            try
            {
                if (u.Email != "") //agregar que pasa si el email ya existe|| u.Email == 
                {
                    context.Add(u);
                    context.SaveChanges();
                    resultado.Ok = true;
                    resultado.CodigoEstado = 200;
                   
                }
                else
                {
                    resultado.Ok = false;
                    resultado.CodigoEstado = 400;
                    resultado.Error = "Existe un problema en el Email";
                }

                if (u.HashContrasenia != null) {
                    context.Add(u);
                    context.SaveChanges();
                    resultado.Ok = true;
                    resultado.CodigoEstado = 200;
                }
                else
                {
                    resultado.Ok = false;
                    resultado.CodigoEstado = 400;
                    resultado.Error = "La contraseña es necesaria";
                }


                return resultado;

            }
            catch (Exception ex)
            {
                resultado.Ok = false;
                resultado.CodigoEstado = 400;
                resultado.Error = "Error al registrar un usuario";
               return resultado;
            }

        }

        public Task<ResultadoBase> PostRegister(Usuario usuario)
        {
            throw new NotImplementedException();
        }

    

    }
}
