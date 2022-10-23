using Microsoft.AspNetCore.Mvc;
using Web.Api.Softijs.Commands.Ventas;
using Web.Api.Softijs.Services.Ventas;

namespace Web.Api.Softijs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidosController : Controller
    {
        private readonly IServicioPedidos _servicioPedidos;

        public PedidosController(IServicioPedidos servicioPedidos)
        {
            _servicioPedidos = servicioPedidos;
        }

        [HttpGet("getPedidosForComboBox")]
        public async Task<IActionResult> GetPedidosForComboBox()
        {
            return Ok(await _servicioPedidos.GetPedidosForComboBox());
        }

        [HttpPost("registrarPedido")]
        public async Task<IActionResult> RegistrarPedido([FromBody] PedidoDto pedidoDto)
        {
            var retVal = await _servicioPedidos.RegistrarPedido(pedidoDto);

            if (retVal.Ok)
                return Ok(retVal);

            return BadRequest(retVal.Message);
        }

        [HttpGet("getPedidos")]
        public async Task<IActionResult> GetPedidos()
        {
            return Ok(await _servicioPedidos.GetPedidos());
        }
    }
}
