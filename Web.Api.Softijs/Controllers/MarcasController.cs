using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Softijs.Services;

namespace Web.Api.Softijs.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MarcasController : ControllerBase
    {
        private readonly IServicioMarcas servicio;

        public MarcasController(IServicioMarcas _servicio)
        {
            this.servicio = _servicio;
        }

        [HttpGet("GetMarcas")]
        public async Task<ActionResult> GetMarcas()
        {
            return Ok(await this.servicio.GetMarcas());
        }
    }
}
