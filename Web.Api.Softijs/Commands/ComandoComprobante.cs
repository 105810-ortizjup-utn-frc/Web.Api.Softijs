using System.ComponentModel.DataAnnotations;

namespace Web.Api.Softijs.Commands
{
    public class ComandoComprobante
    {

     

        [Required(ErrorMessage = "La descripción en requerida.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El archivo es requerido.")]
        public IFormFile file { get; set; }
    }
}
