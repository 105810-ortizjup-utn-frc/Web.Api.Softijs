using Web.Api.Softijs.Models.Interfaces;

namespace Web.Api.Softijs.Models
{
    public partial class Proveedore : IAuditable
    {
        public Proveedore()
        {
            Productos = new HashSet<Producto>();
        }

        public int IdProveedor { get; set; }
        public string Nombre { get; set; } = null!;
        public int? IdInformacionContacto { get; set; }
        public int? IdProvincia { get; set; }
        public int? IdBarrio { get; set; }
        public int? IdCiudad { get; set; }
        public string? Calle { get; set; }
        public int? Numero { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string ModificadoPor { get; set; } = null!;
        public DateTime FechaModificacion { get; set; }
        public string CreadoPor { get; set; } = null!;

        public virtual Provincia? IdProvinciaNavigation { get; set; }
        public virtual Barrio? IdBarrioNavigation { get; set; }
        public virtual Ciudade? IdCiudadNavigation { get; set; }
        public virtual InformacionesContacto? IdInformacionContactoNavigation { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
        public virtual ICollection<DetallesOrdenesPago> Proveedores { get; set; }
    }
}
