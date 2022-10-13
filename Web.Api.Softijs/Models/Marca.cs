using Web.Api.Softijs.Models.Interfaces;

namespace Web.Api.Softijs.Models
{
    public partial class Marca : IAuditable
    {
        public Marca()
        {
            Productos = new HashSet<Producto>();
        }

        public int IdMarca { get; set; }
        public string Codigo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string RazonSocial { get; set; } = null!;
        public int? IdInformacionContacto { get; set; }
        public string CreadoPor { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public string ModificadoPor { get; set; } = null!;
        public DateTime FechaModificacion { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
