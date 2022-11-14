using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Softijs.Services;

namespace Web.Api.Softijs.Controllers
{
    [Authorize]
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
