using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Softijs.Services;

namespace Web.Api.Softijs.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GustosController : ControllerBase
    {
        private readonly IServicioGustos servicio;

        public GustosController(IServicioGustos _servicio)
        {
            this.servicio = _servicio;
        }

        [HttpGet("GetGustos")]
        public async Task<ActionResult> GetGustos()
        {
            return Ok(await this.servicio.GetGustos());
        }
    }
}
