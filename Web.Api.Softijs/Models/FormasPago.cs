using Web.Api.Softijs.Models.Interfaces;

namespace Web.Api.Softijs.Models
{
    public partial class FormasPago : IAuditable
    {
        public FormasPago()
        {
            DetallesOrdenesPagos = new HashSet<DetallesOrdenesPago>();
            Pagos = new HashSet<Pago>();
            Pedidos = new HashSet<Pedido>();
        }

        public int IdFormaPago { get; set; }
        public string Descripcion { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public string ModificadoPor { get; set; } = null!;
        public DateTime FechaModificacion { get; set; }
        public string Codigo { get; set; } = null!;
        public string CreadoPor { get; set; } = null!;

        public virtual ICollection<DetallesOrdenesPago> DetallesOrdenesPagos { get; set; }
        public virtual ICollection<Pago> Pagos { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
