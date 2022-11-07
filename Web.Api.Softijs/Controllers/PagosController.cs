using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Web.Api.Softijs.Commands;
using Web.Api.Softijs.Commands.Ventas;
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
        [Route("GetComprobanteById/{id}")]

        public async Task<ActionResult<DTOComprobanteDePago>> GetComprobanteById(int id)
        {
            return Ok(await this.servicio.GetComprobanteById(id));
        }

        [HttpPost("PostProducto")]
        public async Task<IActionResult> PostComprobante([FromForm] ComandoComprobante comando)
        {


            var id =   await this.servicio.PostComprobante(comando);

            var path = $"{Directory.GetCurrentDirectory()}\\Uploads\\Comprobantes\\";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            using (var fileStream = new FileStream(Path.Combine(path, $"{id}.pdf"), FileMode.Create))
            {
                await comando.file.CopyToAsync(fileStream);
            }

            return Ok();
          
        }
    }
}
