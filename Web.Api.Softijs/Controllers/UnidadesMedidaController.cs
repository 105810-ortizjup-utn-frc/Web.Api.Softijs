﻿using Microsoft.AspNetCore.Mvc;
using Web.Api.Softijs.Services;

namespace Web.Api.Softijs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadesMedidaController : ControllerBase
    {
        private readonly IServicioUnidadesMedidas servicio;
        public UnidadesMedidaController(IServicioUnidadesMedidas _servicio)
        {
            this.servicio = _servicio;
        }

        [HttpGet]
        [Route("GetUnidadesMedidas")]
        public async Task<ActionResult> GetUnidadesMedidas()
        {
            return Ok(await this.servicio.GetUnidadesMedida());
        }
    }
}
