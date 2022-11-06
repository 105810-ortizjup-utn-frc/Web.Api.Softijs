using Web.Api.Softijs.Models;

namespace Web.Api.Softijs.DataTransferObjects
{
    public class DTODetalleOrdenPago
    {
        public int id_detalle_orden { get; set; }
        public int id_forma_pago { get; set; }
        public string? forma_pago { get; set; }
        public decimal? Monto { get; set; }
        public int? liquidacion { get; set; }
        public bool? IdAutorizacion1 { get; set; }
        public bool? IdAutorizacion2 { get; set; }
        public string ModificadoPor { get; set; } = null!;
        public DateTime FechaModificacion { get; set; }
        public string? destinatario { get; set; }

    }
}
