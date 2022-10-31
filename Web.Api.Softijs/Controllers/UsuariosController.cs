using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Softijs.DataTransferObjects;
using Web.Api.Softijs.Models;
using Web.Api.Softijs.Services.Comunes;

namespace Web.Api.Softijs.Controllers
{
    //[Authorize]
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

        [HttpGet("getUsuariosById/{id}")]
        public async Task<DTOUsuarioById> GetUsuariosById(int id)
        {
            return await _servicioUsuarios.GetUsuariosById(id);
        }
    }
}
