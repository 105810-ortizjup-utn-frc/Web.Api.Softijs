using Web.Api.Softijs.Models.Interfaces;

namespace Web.Api.Softijs.Models
{
    public partial class Liquidacione : IAuditable
    {
        public Liquidacione()
        {
            DetallesOrdenesPagos = new HashSet<DetallesOrdenesPago>();
        }

        public int IdLiquidacion { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaLiquidacion { get; set; }
        public int CantidadHoraTrabajada { get; set; }
        public decimal MontoPorHora { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string ModificadoPor { get; set; } = null!;
        public DateTime FechaModificacion { get; set; }
        public string CreadoPor { get; set; } = null!;

        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
        public virtual ICollection<DetallesOrdenesPago> DetallesOrdenesPagos { get; set; }
    }
}
