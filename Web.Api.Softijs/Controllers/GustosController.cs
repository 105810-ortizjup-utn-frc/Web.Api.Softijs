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
    public class GustosController : ControllerBase
    {
        private readonly IServicioGustos servicio;
        public GustosController(IServicioGustos _servicio)
        {
            this.servicio = _servicio;
        }

        [HttpGet]
        [Route("GetGustos")]
        public async Task<ActionResult> GetGustos()
        {
            return Ok(await this.servicio.GetGustos());
        }
    }
}
