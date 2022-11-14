using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Softijs.Commands.Pagos;
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

        [HttpGet("getFormasPagoForComboBox")]
        public async Task<IActionResult> GetFormasPagoForComboBox()
        {
            return Ok(await this.servicio.GetFormasDePagosForComboBoxItem());
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

        [HttpGet("getLiquidacionForList")]
        public async Task<IActionResult> GetLiquidacionesForList()
        {
            return Ok(await this.servicio.GetLiquidacionForList());
        }

        [HttpGet("GetComprobanteDePago")]
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

        [HttpPost("autorizarFirma1")]
        public async Task<ActionResult> AutorizarFirma1([FromBody] int idDetalleOrdern)
        {
            return Ok(await this.servicio.AutorizarFirma1(idDetalleOrdern));
        }


        [HttpPost("autorizarFirma2")]
        public async Task<ActionResult> AutorizarFirma2([FromBody] int idDetalleOrdern)
        {
            return Ok(await this.servicio.AutorizarFirma2(idDetalleOrdern));
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

        [HttpPost("guardarProveedor")]
        public async Task<IActionResult> GuardarProveedor([FromBody]FormularioAltaProveedorDto formularioAltaProveedorDto)
        {
            await this.servicio.SaveProveedor(formularioAltaProveedorDto);
            return Ok();
        }
    }
}
