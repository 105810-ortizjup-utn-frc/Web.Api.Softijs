using Web.Api.Softijs.Models.Interfaces;

namespace Web.Api.Softijs.Models
{
    public partial class Pago : IAuditable
    {
        public Pago()
        {
            DetallesPedidos = new HashSet<DetallesPedido>();
        }

        public int IdPago { get; set; }
        public DateTime FechaPago { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string ModificadoPor { get; set; } = null!;
        public DateTime FechaModificacion { get; set; }
        public int IdFormaPago { get; set; }
        public string CreadoPor { get; set; } = null!;

        public virtual FormasPago IdFormaPagoNavigation { get; set; } = null!;
        public virtual ICollection<DetallesPedido> DetallesPedidos { get; set; }
    }
}
