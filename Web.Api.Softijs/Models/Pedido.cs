using Web.Api.Softijs.Models.Interfaces;

namespace Web.Api.Softijs.Models
{
    public partial class Pedido : IAuditable
    {
        public Pedido()
        {
            DetallesPedidos = new HashSet<DetallesPedido>();
        }

        public int NroPedido { get; set; }
        public DateTime Fecha { get; set; }
        public int IdUsuario { get; set; }
        public int IdCliente { get; set; }
        public string CreadoPor { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public string ModificadoPor { get; set; } = null!;
        public DateTime FechaModificacion { get; set; }
        public int? IdFormaPago { get; set; }
        public int? IdEstadoPedido { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; } = null!;
        public virtual EstadosPedido? IdEstadoPedidoNavigation { get; set; }
        public virtual FormasPago? IdFormaPagoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
        public virtual ICollection<DetallesPedido> DetallesPedidos { get; set; }
    }
}
