using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Softijs.Services.Comunes;

namespace Web.Api.Softijs.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : Controller
    {
        private readonly IServicioUsuarios _servicioUsuarios;

        public UsuariosController(IServicioUsuarios servicioUsuarios)
        {
            _servicioUsuarios = servicioUsuarios;
        }

        [HttpGet("getUsuariosForComboBox")]
        public async Task<ActionResult> GetUsuariosForComboBox()
        {
            return Ok(await _servicioUsuarios.GetUsuariosForComboBox());
        }
    }
}
