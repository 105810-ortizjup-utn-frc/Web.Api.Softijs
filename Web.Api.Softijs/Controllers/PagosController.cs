using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Softijs.Comun;
using Web.Api.Softijs.DataTransferObjects;
using Web.Api.Softijs.Models;
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

        private async Task<ActionResult<DTOComprobanteDePago>> GetComprobanteById(int id)
        {
            return Ok(await this.servicio.GetComprobanteById(id));

        }
    }
}
