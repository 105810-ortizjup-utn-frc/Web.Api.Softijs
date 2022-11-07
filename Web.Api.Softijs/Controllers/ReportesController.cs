using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Api.Softijs.Services;

namespace Web.Api.Softijs.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ReportesController : Controller
    {
        private readonly IServicioReportes servicio;

        public ReportesController(IServicioReportes _servicio)
        {
            this.servicio = _servicio;
        }

        [HttpGet("GetRendimientoVendedor/{id}")]
        public async Task<ActionResult> GetProveedores(int id)
        {
            return Ok(await this.servicio.GetRedimientoVendedor(id));
        }

        [HttpGet("GetMontoVendido/{id}")]
        public async Task<ActionResult> GetMontoVendido(int id)
        {
            return Ok(await this.servicio.GetMontoTotal(id));
        }

        [HttpGet("GetEstadisticaClientes")]
        public async Task<ActionResult> GetEstadisticaClientes()
        {
            return Ok(await this.servicio.GetEstadisticaClientes());
        }
    }
}
