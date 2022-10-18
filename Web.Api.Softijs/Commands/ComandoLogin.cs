using System.ComponentModel.DataAnnotations;

namespace Web.Api.Softijs.Commands
{
    public class ComandoLogin
    {

        [Required(ErrorMessage ="El email es necesario")]
        public string Email { get; set; }


        [Required(ErrorMessage = "La contraseña es necesaria")]
        public string Contrasenia { get; set; }
    }
}
