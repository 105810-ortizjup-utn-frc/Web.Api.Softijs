using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
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

        [HttpPost("PostRegister")]
        public async Task<ActionResult<ResultadoBase>> PostRegister([FromBody] ComandoRegister comando)
        {
            Usuario r = new Usuario();

            byte[] ePass = GetHash(comando.Contrasenia);

            r.Nombre = comando.Nombre;
            r.Email = comando.Email;
            r.Apellido = comando.Apellido;
            r.Legajo = comando.Legajo;
            r.IdTipoUsuario = 1;
            r.Activo = true;
            r.HashContrasenia = ePass;



            return Ok(await this.servicio.PostRegister(r));
        }

        private byte[] GetHash(string key)
        {
            var bytes = Encoding.UTF8.GetBytes(key);
            return new SHA256Managed().ComputeHash(bytes);
        }
    }
}
