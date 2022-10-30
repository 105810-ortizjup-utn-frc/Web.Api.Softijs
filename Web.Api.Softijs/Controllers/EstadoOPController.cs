using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Softijs.Services.Pagos;

namespace Web.Api.Softijs.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoOPController : ControllerBase
    {
        private readonly IServicioEstadoOP servicio;

        public EstadoOPController(IServicioEstadoOP _servicio)
        {
            this.servicio = _servicio;
        }

        [HttpGet("GetEstado")]
        public async Task<ActionResult> GetEstado()
        {
            return Ok(await this.servicio.GetEstado());
        }
    }
}
