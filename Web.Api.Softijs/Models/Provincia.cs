using Web.Api.Softijs.Models.Interfaces;

namespace Web.Api.Softijs.Models
{
    public partial class Provincia : IAuditable
    {
        public Provincia()
        {
            Proveedores = new HashSet<Proveedore>();
         }

        public int IdProvincia { get; set; }
        public string Codigo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string CreadoPor { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public string ModificadoPor { get; set; } = null!;
        public DateTime FechaModificacion { get; set; }

        public virtual ICollection<Proveedore> Proveedores { get; set; }
    }
}
