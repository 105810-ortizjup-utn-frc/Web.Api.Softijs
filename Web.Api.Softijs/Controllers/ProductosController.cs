using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Api.Softijs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IServicioProducto servicio;
        public ProductosController(IServicioProducto _servicio)
        {
            this.servicio = _servicio;
        }

        [HttpGet]
        [Route("GetProductos")]

        public async Task<ActionResult> GetProductos()
        {
            return Ok(this.servicio.GetProductos());
        }
    }
}
