using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Softijs.Services;
using Web.Api.Softijs.Services.Pagos;

namespace Web.Api.Softijs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoOPController : ControllerBase
    {
        private readonly IServicioEstadoOP servicio;
        public EstadoOPController(IServicioEstadoOP _servicio)
        {
            this.servicio = _servicio;
        }

        [HttpGet]
        [Route("GetEstado")]

        public async Task<ActionResult> GetEstado()
        {
            return Ok(await this.servicio.GetEstado());
        }
    }
}
