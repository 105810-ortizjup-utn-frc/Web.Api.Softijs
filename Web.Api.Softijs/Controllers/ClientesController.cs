using Microsoft.AspNetCore.Mvc;
using Web.Api.Softijs.Commands;
using Web.Api.Softijs.Commands.Ventas;
using Web.Api.Softijs.Models;
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

        [HttpGet("getClientes")]
        public async Task<ActionResult> GetClientes()
        {
            return Ok(await _servicioClientes.GetClientes());
        }

        [HttpGet("getInfoContacto")]
        public async Task<ActionResult> GetInfoContacto()
        {
            return Ok(await _servicioClientes.GetInfoContacto());
        }

        [HttpPost("postCliente")]
        public async Task<IActionResult> PostCliente([FromBody] ComandoCliente cliente)
        {
            var retVal = await _servicioClientes.PostCliente(cliente);

            if (retVal.Ok)
                return Ok(retVal);

            return BadRequest(retVal.Message);
        }
    }
}
