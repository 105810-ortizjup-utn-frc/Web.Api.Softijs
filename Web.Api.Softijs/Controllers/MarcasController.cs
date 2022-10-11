using Microsoft.AspNetCore.Http;
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
    public class MarcasController : ControllerBase
    {
        private readonly IServicioMarcas servicio;
        public MarcasController(IServicioMarcas _servicio)
        {
            this.servicio = _servicio;
        }

        [HttpGet]
        [Route("GetMarcas")]

        public async Task<ActionResult> GetMarcas()
        {
            return Ok(this.servicio.GetMarcas());
        }
    }
}
