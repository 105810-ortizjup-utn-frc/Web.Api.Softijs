using Microsoft.AspNetCore.Mvc;
using Web.Api.Softijs.Commands.Ventas;
using Web.Api.Softijs.Services;

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

        [HttpPost]
        [Route("RegistrarPedido")]
        public async Task<IActionResult> RegistrarPedido([FromBody] PedidoDto pedidoDto)
        {
            var retVal = await _servicioPedidos.RegistrarPedido(pedidoDto);

            if (retVal.Ok)
                return Ok(retVal.Message);

            return BadRequest(retVal.Message);
        }
    }
}
