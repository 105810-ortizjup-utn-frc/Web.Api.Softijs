using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Softijs.Commands.Pagos;
using Web.Api.Softijs.Comun;
using Web.Api.Softijs.Services.Pagos;

namespace Web.Api.Softijs.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PagosController : ControllerBase
    {

        private readonly IServicioPagos servicio;

        public PagosController(IServicioPagos _servicio)
        {
            this.servicio = _servicio;
        }

        [HttpGet("GetOrdenesDePagos")]
        public async Task<ActionResult> GetOrdenP()
        {
            return Ok(await this.servicio.GetOrdenP());
        }


        [HttpGet]
        [Route("GetPagosPendientes")]

        public async Task<ActionResult> GetPagosPendientes()
        {
            return Ok(await this.servicio.GetPagosPendientes());
        }

        [HttpPost("saveOrdenPago")]
        public async Task<IActionResult> SaveOrdenPago([FromBody] AltaOrdenPagoDto dto)
        {
            return Ok(await this.servicio.SaveOrdenPago(dto));
        }

        [HttpPost("getOrdenPagoForUpdate/{id}")]
        public async Task<IActionResult> GetOrdenPagoForUpdate(int id)
        {
            return Ok(await this.servicio.GetAltaOrdenPagoDtoById(id));
        }

        [HttpGet("getProveedoresForComboBox")]
        public async Task<IActionResult> GetProveedoresForComboBox()
        {
            return Ok(await this.servicio.GetProveedoresForComboBox());
        }

        [HttpGet("getLiquidacionesForComboBox")]
        public async Task<IActionResult> GetLiquidacionesForComboBox()
        {
            return Ok(await this.servicio.GetLiquidacionForComboBox());
        }
    }
}
