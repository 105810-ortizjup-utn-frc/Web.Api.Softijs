using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Softijs.Commands;
using Web.Api.Softijs.Results;
using Web.Api.Softijs.Services.Comunes;
using Web.Api.Softijs.Services.Security;

namespace Web.Api.Softijs.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : Controller
    {
        private readonly IServicioClientes _servicioClientes;

        private readonly ISecurityService _securityService;

        public ClientesController(IServicioClientes servicioClientes, ISecurityService securityService)
        {
            _servicioClientes = servicioClientes;
            _securityService = securityService;
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

        [HttpPut("putCliente/{id}")]
        public async Task<IActionResult> PutCliente([FromBody] ComandoCliente cliente)
        {
            if (!_securityService.CheckUserHasroles(new string[] { "Admin" }))
            {
                return StatusCode(StatusCodes.Status403Forbidden, "No tiene los permisos para ejecutar esta acción.");
            } else
            {
                var retVal = await _servicioClientes.PutCliente(cliente);

                if (retVal.Ok)
                    return Ok(retVal);

                return BadRequest(retVal.Message);
            }
        }

        [HttpGet("getClienteByID/{id}")]
        public async Task<IActionResult> GetClienteByID(int id)
        {
            return Ok(await _servicioClientes.GetClienteByID(id));
        }

        [HttpDelete]
        [Route("deleteSoftCliente/{id}")]

        public async Task<ActionResult<ResultadoBase>> DeleteCliente(int id)
        {
            if (!_securityService.CheckUserHasroles(new string[] { "Admin" }))
                return StatusCode(StatusCodes.Status403Forbidden, "No tiene los permisos para ejecutar esta acción.");

            return Ok(await this._servicioClientes.DeleteCliente(id));
        }
    }
}
