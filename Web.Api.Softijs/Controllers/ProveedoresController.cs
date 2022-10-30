using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Softijs.Services;

namespace Web.Api.Softijs.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedoresController : Controller
    {
        private readonly IServicioProveedores servicio;

        public ProveedoresController(IServicioProveedores _servicio)
        {
            this.servicio = _servicio;
        }

        [HttpGet("GetProveedores")]
        public async Task<ActionResult> GetProveedores()
        {
            return Ok(await this.servicio.GetProveedores());
        }
    }
}
