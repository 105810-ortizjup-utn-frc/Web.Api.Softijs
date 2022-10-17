using System.ComponentModel.DataAnnotations;

namespace Web.Api.Softijs.Commands
{
    public class ComandoLogin
    {
        [Required(ErrorMessage ="El email es requerido")]
        public string Email { get; set; }

        [Required(ErrorMessage ="La contrseña es requerida")]
        public string Contrasenia { get; set; }
    }
}
