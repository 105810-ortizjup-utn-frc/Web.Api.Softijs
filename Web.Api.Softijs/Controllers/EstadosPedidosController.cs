using Microsoft.AspNetCore.Mvc;
using Web.Api.Softijs.Services.Ventas;

namespace Web.Api.Softijs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstadosPedidosController : Controller
    {
        private IServicioEstadosPedidos _servicioEstadosPedidos;

        public EstadosPedidosController(IServicioEstadosPedidos servicioEstadosPedidos)
        {
            _servicioEstadosPedidos = servicioEstadosPedidos;
        }

        [HttpGet("getEstadosPedidosForComboBox")]
        public async Task<IActionResult> GetEstadosPedidosForComboBox()
        {
            return Ok(await _servicioEstadosPedidos.GetEstadosPedidosForComboBox());
        }
    }
}
