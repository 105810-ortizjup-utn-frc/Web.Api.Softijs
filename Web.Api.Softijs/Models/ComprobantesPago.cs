using Web.Api.Softijs.Models.Interfaces;

namespace Web.Api.Softijs.Models
{
    public partial class ComprobantesPago : IAuditable
    {
        public ComprobantesPago()
        {
            DetallesOrdenesPagos = new HashSet<DetallesOrdenesPago>();
        }

        public int IdComprobantePago { get; set; }
        public int NroComprobante { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string ModificadoPor { get; set; } = null!;
        public DateTime FechaModificacion { get; set; }
        public string CreadoPor { get; set; } = null!;

        public virtual ICollection<DetallesOrdenesPago> DetallesOrdenesPagos { get; set; }
    }
}
