using Microsoft.AspNetCore.Mvc;
using Web.Api.Softijs.Services.Comunes;

namespace Web.Api.Softijs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormasPagosController : Controller
    {
        private readonly IServicioFormasPagos _servicioFormasPagos;

        public FormasPagosController(IServicioFormasPagos servicioFormasPagos)
        {
            _servicioFormasPagos = servicioFormasPagos;
        }

        [HttpGet("getFormasPagosForComboBox")]
        public async Task<IActionResult> GetFormasPagosForComboBox()
        {
            return Ok(await _servicioFormasPagos.GetFormasPagosForComboBox());
        }
    }
}
