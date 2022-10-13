using Web.Api.Softijs.Models.Interfaces;

namespace Web.Api.Softijs.Models
{
    public partial class Producto : IAuditable
    {
        public Producto()
        {
            DetallesPedidos = new HashSet<DetallesPedido>();
            Puntos = new HashSet<Punto>();
        }

        public int NroProducto { get; set; }
        public string Nombre { get; set; } = null!;
        public DateTime FechaVencimiento { get; set; }
        public int IdProveedor { get; set; }
        public decimal Precio { get; set; }
        public string Lote { get; set; } = null!;
        public int PuntoNecesario { get; set; }
        public int PuntoOtorgado { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string ModificadoPor { get; set; } = null!;
        public DateTime FechaModificacion { get; set; }
        public int IdUnidadMedida { get; set; }
        public int IdGusto { get; set; }
        public int IdMarca { get; set; }
        public string CreadoPor { get; set; } = null!;
        public int IdCategoria { get; set; }
        public int Codigo { get; set; }

        public virtual Categoria IdCategoriaNavigation { get; set; } = null!;
        public virtual Gusto IdGustoNavigation { get; set; } = null!;
        public virtual Marca IdMarcaNavigation { get; set; } = null!;
        public virtual Proveedore IdProveedorNavigation { get; set; } = null!;
        public virtual UnidadesMedida IdUnidadMedidaNavigation { get; set; } = null!;
        public virtual ICollection<DetallesPedido> DetallesPedidos { get; set; }
        public virtual ICollection<Punto> Puntos { get; set; }
    }
}
