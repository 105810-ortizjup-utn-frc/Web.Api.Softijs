using Web.Api.Softijs.Models.Interfaces;

namespace Web.Api.Softijs.Models
{
    public partial class DetallesPedido : IAuditable
    {
        public int NroDetallePedido { get; set; }
        public int NroProducto { get; set; }
        public int NroPedido { get; set; }
        public decimal Monto { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string ModificadoPor { get; set; } = null!;
        public DateTime FechaModificacion { get; set; }
        public string CreadoPor { get; set; } = null!;
        public int? IdPago { get; set; }

        public virtual Pago? IdPagoNavigation { get; set; }
        public virtual Pedido NroPedidoNavigation { get; set; } = null!;
        public virtual Producto NroProductoNavigation { get; set; } = null!;
    }
}
