using Web.Api.Softijs.Models.Interfaces;

namespace Web.Api.Softijs.Models
{
    public partial class Autorizacione : IAuditable
    {
        public Autorizacione()
        {
            DetallesOrdenesPagoIdAutorizacion1Navigations = new HashSet<DetallesOrdenesPago>();
            DetallesOrdenesPagoIdAutorizacion2Navigations = new HashSet<DetallesOrdenesPago>();
        }

        public int IdAutorizacion { get; set; }
        public string CreadoPor { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public string ModificadoPor { get; set; } = null!;
        public DateTime FechaModificacion { get; set; }

        public virtual ICollection<DetallesOrdenesPago> DetallesOrdenesPagoIdAutorizacion1Navigations { get; set; }
        public virtual ICollection<DetallesOrdenesPago> DetallesOrdenesPagoIdAutorizacion2Navigations { get; set; }
    }
}
