using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Softijs.Commands.Ventas;
using Web.Api.Softijs.Services.Ventas;

namespace Web.Api.Softijs.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PedidosController : Controller
    {
        private readonly IServicioPedidos _servicioPedidos;
        private readonly IServicioFacturas _servicioFacturas;

        public PedidosController(IServicioPedidos servicioPedidos, IServicioFacturas servicioFacturas)
        {
            _servicioPedidos = servicioPedidos;
            _servicioFacturas = servicioFacturas;
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

        [HttpGet("getDetallePedido/{id}")]
        public async Task<IActionResult> GetPedidos(int id)
        {
            return Ok(await _servicioPedidos.GetDetallePedidos(id));
        }

        [HttpGet("imprimirFactura/{nroPedido}")]
        public async Task<IActionResult> ImprimirFactura(int nroPedido)
        {
            var file = await _servicioFacturas.CrearFactura(nroPedido);
            return File(file, "application/pdf");
        }
    }
}
