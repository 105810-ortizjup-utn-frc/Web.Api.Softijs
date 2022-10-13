using Web.Api.Softijs.Models.Interfaces;

namespace Web.Api.Softijs.Models
{
    public partial class OrdenesPago : IAuditable
    {
        public OrdenesPago()
        {
            DetallesOrdenesPagos = new HashSet<DetallesOrdenesPago>();
        }

        public int IdOrdenPago { get; set; }
        public int IdTipoOrdenPago { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string ModificadoPor { get; set; } = null!;
        public int IdEstadoOrdenPago { get; set; }
        public string CreadoPor { get; set; } = null!;

        public virtual EstadosOrdenesPago IdEstadoOrdenPagoNavigation { get; set; } = null!;
        public virtual TiposOrdenesPago IdTipoOrdenPagoNavigation { get; set; } = null!;
        public virtual ICollection<DetallesOrdenesPago> DetallesOrdenesPagos { get; set; }
    }
}
