using System.Text;
using System.Security.Cryptography;
using Web.Api.Softijs.Results;
using Web.Api.Softijs.Models;
using Web.Api.Softijs.DataContext;
using Web.Api.Softijs.Commands;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Web.Api.Softijs.Services

{
    public class ServicioRegister : IServicioRegister
    {
        
       

        private readonly SoftijsDevContext context;
        public ServicioRegister(SoftijsDevContext _context) { this.context = _context; }
        public async Task<ResultadoBase> PostRegister(Usuario u) 
        {
            ResultadoBase resultado = new ResultadoBase();

            if (this.ValidarMail(u.Email)) {
                if (this.validarExpresion(u.Email)) {
                    if (this.ValidarLegajo(u.Legajo)) { 

                        try
            {    
                    context.Add(u);
                    context.SaveChanges("jero");
                    resultado.Ok = true;
                    resultado.CodigoEstado = 200;
                    return resultado;   

            } catch (Exception )
            {
                resultado.Ok = false;
                resultado.CodigoEstado = 400;
                resultado.Error = "Error al registrar un usuario";
                return resultado;
            }
                         }
                    resultado.Ok = false;
                    resultado.CodigoEstado = 400;
                    resultado.Error = "El Legajo ya pertenece a un usuario";
                    return resultado;

                }
                resultado.Ok = false;
                resultado.CodigoEstado = 400;
                resultado.Error = "El Email no es valido, utilice expresiones correspondientes";
                return resultado;

            }
            resultado.Ok = false;
            resultado.CodigoEstado = 400;
            resultado.Error = "Ya existe el Email ingresado";
            return resultado;

        }

        private bool ValidarMail(string email)
        {
            var usuario = context.Usuarios.Where(c => c.Email.Equals(email)).FirstOrDefault();
            if (usuario != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool ValidarLegajo(string legajo)
        {
            var usuario = context.Usuarios.Where(c => c.Legajo.Equals(legajo)).FirstOrDefault();
            if (usuario != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool validarExpresion(string email)
        {
            return email != null && Regex.IsMatch(email, "^(([\\w-]+\\.)+[\\w-]+|([a-zA-Z]{1}|[\\w-]{2,}))@(([a-zA-Z]+[\\w-]+\\.){1,2}[a-zA-Z]{2,4})$");
        }

       
        
    }
}
