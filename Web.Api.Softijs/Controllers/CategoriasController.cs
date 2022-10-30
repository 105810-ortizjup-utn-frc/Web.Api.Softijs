using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Softijs.Services;

namespace Web.Api.Softijs.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly IServicioCategoria servicio;

        public CategoriasController(IServicioCategoria _servicio)
        {
            this.servicio = _servicio;
        }

        [HttpGet("GetCategorias")]
        public async Task<ActionResult> GetCategorias()
        {
            return Ok(await this.servicio.GetCategorias());
        }
    }
}
