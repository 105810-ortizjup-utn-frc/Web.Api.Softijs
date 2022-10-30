using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using Web.Api.Softijs.Comun;
using Web.Api.Softijs.DataContext;
using Web.Api.Softijs.Models;
using Web.Api.Softijs.Results;
using Web.Api.Softijs.Services.Security;

namespace Web.Api.Softijs.Services

{
    public class ServicioRegister : IServicioRegister
    {
        private readonly SoftijsDevContext context;
        private readonly ISecurityService _securityService;

        public ServicioRegister(SoftijsDevContext _context, ISecurityService securityService) { this.context = _context; _securityService = securityService; }

        public async Task<ResultadoBase> PostRegister(Usuario u)
        {
            ResultadoBase resultado = new ResultadoBase();

            if (this.ValidarMail(u.Email))
            {
                if (this.validarExpresion(u.Email))
                {
                    if (await this.ValidarLegajo(u.Legajo))
                    {

                        try
                        {
                            await context.AddAsync(u);
                            await context.SaveChangesAsync(_securityService.GetUserName() ?? Constantes.DefaultSecurityValues.DefaultUserName);
                            resultado.Ok = true;
                            resultado.CodigoEstado = 200;
                            return resultado;

                        }
                        catch (Exception)
                        {
                            resultado.Ok = false;
                            resultado.CodigoEstado = 400;
                            resultado.Error = "Error al registrar un usuario";
                            return resultado;
                        }
                    }
                    resultado.Ok = false;
                    resultado.CodigoEstado = 400;
                    resultado.Error = "El legajo ya pertenece a un usuario";
                    return resultado;

                }
                resultado.Ok = false;
                resultado.CodigoEstado = 400;
                resultado.Error = "El correo no es valido, utilice expresiones correspondientes";
                return resultado;

            }
            resultado.Ok = false;
            resultado.CodigoEstado = 400;
            resultado.Error = "Ya existe el correo ingresado";
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
        private async Task<bool> ValidarLegajo(string legajo)
        {
            var usuario = await context.Usuarios.FirstOrDefaultAsync(c => c.Legajo == legajo);
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
