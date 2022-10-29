using Microsoft.AspNetCore.Mvc;
using Web.Api.Softijs.Services;
using Web.Api.Softijs.Services.Comunes;

namespace Web.Api.Softijs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoFidelizacionController : Controller
    {
        private readonly IServicioTipoFidelizacion _servicioTipoFidelizacion;

        public TipoFidelizacionController(IServicioTipoFidelizacion servicioTipoFidelizacion)
        {
            _servicioTipoFidelizacion = servicioTipoFidelizacion;
        }

        [HttpGet("getTiposFidelizaciones")]
        public async Task<IActionResult> GetTipoFidelizacion()
        {
            return Ok(await _servicioTipoFidelizacion.GetTipoFidelizacion());
        }
    }
}
