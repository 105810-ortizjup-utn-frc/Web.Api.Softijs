using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Api.Softijs.Commands;
using Web.Api.Softijs.DataContext;
using Web.Api.Softijs.Models;
using Web.Api.Softijs.Results.Login;
using Web.Api.Softijs.Services;

namespace Web.Api.Softijs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {

        private readonly IServicioLogin servicio;
        public LoginController(IServicioLogin _servicio, SoftijsDevContext context)
        {
            this.servicio = _servicio;
        }


        [HttpGet]
        [Route("GetUsuarios")]

        public async Task<ActionResult> GetUsuarios()
        {
            return Ok(this.servicio.GetUsuarios());
        }

        [HttpPost]
        [Route("PostLogin")]
        public async Task<ActionResult<ResultadoLogin>> Login([FromBody]ComandoLogin comando)
        {
         
           return Ok(await this.servicio.Login(comando));        
          
        }


        //[HttpPost]
        //[Route("AgregarUsuario")]
        //public ActionResult Agregar()
        //{
        //    this.servicio.Agregar();
        //    return Ok();

        //}
    }
}
