using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Softijs.Comun;
using Web.Api.Softijs.DataTransferObjects;
using Web.Api.Softijs.Results;
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

        [HttpGet]
        [Route("GetComprobanteDePago")]
        public async Task<ActionResult> GetComprobantePago()
        {
            return Ok(await this.servicio.GetComprobantePago());
        }


        [HttpGet]
        [Route("GetDetallesOrdenesPagos/{id}")]
        public async Task<ActionResult> GetDetallesOrdenesPago(int id)
        {
            return Ok(await this.servicio.GetDetallesOrdenesPago(id));
        }

        [HttpGet("descargarComprobante/{idComprobante}")]
        public async Task<IActionResult> DescargarComprobante(int idComprobante)
        {
            var directorio = $"{Directory.GetCurrentDirectory()}\\Uploads\\Comprobantes\\{idComprobante}.pdf";
            if (!System.IO.File.Exists(directorio))
            {
                return NotFound("El archivo no existe!!");
            }
            var file = await System.IO.File.ReadAllBytesAsync(directorio);
            return File(file, "application/pdf");

        }

        [HttpPut("autorizarFirma1")]

        public async Task<ActionResult<ResultadoBase>> AutorizarFirma1([FromBody] int idDetalleOrdenPago)
        {
            return Ok(await this.servicio.AutorizarFirma1(idDetalleOrdenPago));
        }


        [HttpPut("autorizarFirma2")]

        public async Task<ActionResult<ResultadoBase>> AutorizarFirma2([FromBody] int idDetalleOrdenPago)
        {
            return Ok(await this.servicio.AutorizarFirma2(idDetalleOrdenPago));
        }
        

        [HttpGet("detalleLiquidacion")]
        public async Task<ActionResult> GetDetalleLiquidacion()
        {
            return Ok(await this.servicio.GetDetallesLiquidaciones());
        }

        
        [HttpGet("Liquidacion/{id}")]
        public async Task<ActionResult<DTOLiquidaciones>> GetLiquidacionById(int id)
        {
            return Ok(await this.servicio.GetLiquidacionesById(id));
        }


        [HttpGet]
        [Route("GetOrdenById/{id}")]

        public async Task<ActionResult<DTOestadoOP>> GetOrdenPagoById(int id)
        {
            return Ok(await this.servicio.GetOrdenPagoById(id));
        }

        [HttpPut("PutOrden")]

        public async Task<ActionResult<ResultadoBase>> PutOrden([FromBody] DTOestadoOP comando)
        {
            DTOestadoOP o = new DTOestadoOP();
            o.nroOrden = comando.nroOrden;
            o.estado = comando.estado;

            return Ok(await this.servicio.PutOrden(o));
        }

        [HttpGet]
        [Route("GetComprobanteById/{id}")]

        public async Task<ActionResult<DTOComprobanteDePago>> GetComprobanteById(int id)
        {
            return Ok(await this.servicio.GetComprobanteById(id));
        }
    }
}
