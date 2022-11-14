using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Softijs.Services.Comunes;

namespace Web.Api.Softijs.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BarriosController : Controller
    {

        private readonly IServicioBarrios _servicioBarrios;

        public BarriosController(IServicioBarrios servicioBarrios)
        {
            _servicioBarrios = servicioBarrios;
        }

        [HttpGet("getBarrios")]
        public async Task<IActionResult> GetBarrios()
        {
            return Ok(await _servicioBarrios.GetBarrios());
        }

        [HttpGet("getCiudades")]
        public async Task<IActionResult> GetCiudades()
        {
            return Ok(await _servicioBarrios.GetCiudades());
        }

        [HttpGet("getProvincia")]
        public async Task<IActionResult> GetProvincias()
        {
            return Ok(await _servicioBarrios.GetProvincias());
        }

    }
}
