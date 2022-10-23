using Web.Api.Softijs.Models.Interfaces;

namespace Web.Api.Softijs.Models
{
    public partial class PedidosFormasPago : IAuditable
    {
        public int IdPedidoFormasPago { get; set; }
        public int IdFormaPago { get; set; }
        public int NroPedido { get; set; }
        public decimal Monto { get; set; }
        public string CreadoPor { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public string ModificadoPor { get; set; } = null!;
        public DateTime FechaModificacion { get; set; }

        public virtual FormasPago IdFormaPagoNavigation { get; set; } = null!;
        public virtual Pedido NroPedidoNavigation { get; set; } = null!;
    }
}
