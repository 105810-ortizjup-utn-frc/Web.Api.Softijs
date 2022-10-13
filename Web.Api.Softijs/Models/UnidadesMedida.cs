using Web.Api.Softijs.Models.Interfaces;

namespace Web.Api.Softijs.Models
{
    public partial class UnidadesMedida : IAuditable
    {
        public UnidadesMedida()
        {
            Productos = new HashSet<Producto>();
        }

        public int IdUnidadMedida { get; set; }
        public string Descripcion { get; set; } = null!;
        public string CreadoPor { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public string ModificadoPor { get; set; } = null!;
        public DateTime FechaModificacion { get; set; }
        public string Codigo { get; set; } = null!;

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
