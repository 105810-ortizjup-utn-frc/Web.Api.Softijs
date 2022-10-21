using System.ComponentModel.DataAnnotations;

namespace Web.Api.Softijs.Commands
{
    public class ComandoRegister
    {
        //[MaxLength(2,ErrorMessage = "Te pasaste")]
        [Required(ErrorMessage = "El Nombre es requerido.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El apellido es requerido.")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "El legajo es requerido.")]
        public string Legajo { get; set; }
        [Required(ErrorMessage = "El email es requerido.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "La contraseña es requerida.")]
        public string Contrasenia { get; set; }


    }
}
