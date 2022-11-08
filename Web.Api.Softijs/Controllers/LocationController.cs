using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Softijs.Services.Comunes;

namespace Web.Api.Softijs.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : Controller
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet("getProvinciasForComboBox")]
        public async Task<IActionResult> GetPronvinciasForComboBoxItem()
        {
            return Ok(await _locationService.GetProvinciasForComboBox());
        }

        [HttpGet("getCiudadesForComboBox")]
        public async Task<IActionResult> GetCiudadesForComboBoxItem()
        {
            return Ok(await _locationService.GetCiudadesForComboBox());
        }

        [HttpGet("getBarriosForComboBox")]
        public async Task<IActionResult> GetBarriosForComboBoxItem()
        {
            return Ok(await _locationService.GetBarriosForComboBox());
        }
    }
}
