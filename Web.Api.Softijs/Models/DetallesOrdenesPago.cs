using Web.Api.Softijs.Models.Interfaces;

namespace Web.Api.Softijs.Models
{
    public partial class DetallesOrdenesPago : IAuditable
    {
        public int IdDetalleOrdenPago { get; set; }
        public int IdFormaPago { get; set; }
        public int? IdLiquidacion { get; set; }
        public int? IdOrdenPago { get; set; }
        public int IdComprobantePago { get; set; }
        public decimal? Monto { get; set; }
        public int? IdAutorizacion1 { get; set; }
        public int? IdAutorizacion2 { get; set; }
        public string CreadoPor { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public string ModificadoPor { get; set; } = null!;
        public DateTime FechaModificacion { get; set; }

        public virtual Autorizacione? IdAutorizacion1Navigation { get; set; }
        public virtual Autorizacione? IdAutorizacion2Navigation { get; set; }
        public virtual ComprobantesPago IdComprobantePagoNavigation { get; set; } = null!;
        public virtual FormasPago IdFormaPagoNavigation { get; set; } = null!;
        public virtual Liquidacione? IdLiquidacionNavigation { get; set; }
        public virtual OrdenesPago? IdOrdenPagoNavigation { get; set; }
    }
}
