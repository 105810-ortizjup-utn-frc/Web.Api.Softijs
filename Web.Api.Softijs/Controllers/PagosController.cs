using Microsoft.AspNetCore.Mvc;
using Web.Api.Softijs.Services.Pagos;

namespace Web.Api.Softijs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagosController : ControllerBase
    {

        private readonly IServicioPagos servicio;
        public PagosController(IServicioPagos _servicio)
        {
            this.servicio = _servicio;
        }



        [HttpGet]
        [Route("GetOrdenesDePagos")]

        public async Task<ActionResult> GetOrdenP()
        {
            return Ok(await this.servicio.GetOrdenP());
        }
    }
}
