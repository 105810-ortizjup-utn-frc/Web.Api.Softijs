using Microsoft.AspNetCore.Mvc;
using Web.Api.Softijs.Commands;
using Web.Api.Softijs.DataContext;
using Web.Api.Softijs.Results;
using Web.Api.Softijs.Services;

namespace Web.Api.Softijs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {

        private readonly IServicioLogin servicio;
        public LoginController(IServicioLogin _servicio, SoftijsDevContext context)
        {
            this.servicio = _servicio;
        }


        [HttpGet]
        [Route("GetUsuarios")]

        public async Task<ActionResult> GetUsuarios()
        {
            return Ok(this.servicio.GetUsuarios());
        }

        [HttpPost]
        [Route("PostLogin")]
        public async Task<ActionResult<ResultadoBase>> Login([FromBody] ComandoLogin comando)
        {

            return Ok(await this.servicio.Login(comando));

        }
    }
}