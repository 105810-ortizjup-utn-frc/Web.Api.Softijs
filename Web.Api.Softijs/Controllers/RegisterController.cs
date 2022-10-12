using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Softijs.Commands;
using Web.Api.Softijs.Models;
using Web.Api.Softijs.Results;
using Web.Api.Softijs.Services;

namespace Web.Api.Softijs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {

        private readonly IServicioRegister servicio;

        public RegisterController(IServicioRegister _servicio)
        {
            this.servicio = _servicio;
        }

        [HttpPost]
        [Route("PostRegister")]

        public async Task<ActionResult<ResultadoBase>> PostRegister([FromBody] ComandoRegister comando)
        {
            Usuario r = new Usuario();

            r.Nombre = comando.Nombre;
            r.Email = comando.Email;


            r.ModificadoPor = comando.ModificadoPor;
            r.FechaCreacion = comando.FechaCreacion;
            r.FechaModificacion = comando.FechaModificacion;


            return Ok(this.servicio.PostRegister(r));
        }











    }
}
