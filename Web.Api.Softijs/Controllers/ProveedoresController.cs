using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Api.Softijs.Services;

namespace Web.Api.Softijs.Controllers
{
    public class ProveedoresController : Controller
    {
        private readonly IServicioProveedores servicio;
        public ProveedoresController(IServicioProveedores _servicio)
        {
            this.servicio = _servicio;
        }

        [HttpGet]
        [Route("GetProveedores")]
        public async Task<ActionResult> GetGustos()
        {
            return Ok(this.servicio.GetProveedores());
        }
    }
}
