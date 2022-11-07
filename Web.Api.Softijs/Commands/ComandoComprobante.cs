using System.ComponentModel.DataAnnotations;

namespace Web.Api.Softijs.Commands
{
    public class ComandoComprobante
    {

     
        public int idDetalle { get; set; }
        [Required(ErrorMessage = "La descripción en requerida.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El archivo es requerido.")]
        public IFormFile file { get; set; }

        //[Required(ErrorMessage = "La Fecha creacion en requerida.")]
        //public DateTime FechaCreacion { set; get; }

        //[Required(ErrorMessage = "El creador es requerido.")]
        //public string? CreadoPor { set; get; }

        //[Required(ErrorMessage = "La Fecha modificacion en requerida.")]
        //public DateTime FechaModificacion { set; get; }

        //[Required(ErrorMessage = "El modificador es requerido.")]
        //public string? ModificadoPor { set; get; }

    }
}
