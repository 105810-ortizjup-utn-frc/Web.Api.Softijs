using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Softijs.Services.Comunes;

namespace Web.Api.Softijs.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : Controller
    {
        private readonly IServicioClientes _servicioClientes;

        public ClientesController(IServicioClientes servicioClientes)
        {
            _servicioClientes = servicioClientes;
        }

        [HttpGet("getClientesForComboBox")]
        public async Task<ActionResult> GetClientesForComboBox()
        {
            return Ok(await _servicioClientes.GetClientesForComboBox());
        }
    }
}
