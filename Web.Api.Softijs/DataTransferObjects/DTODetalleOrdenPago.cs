using Web.Api.Softijs.Models;

namespace Web.Api.Softijs.DataTransferObjects
{
    public class DTODetalleOrdenPago
    {
        public int IdDetalleOrden { get; set; }
        public int IdFormaPago { get; set; }
        public string? FormaPago { get; set; }
        public decimal? Monto { get; set; }
        public int? Liquidacion { get; set; }
        public int IdTipoOrden { get; set; }
        public bool? IdAutorizacion1 { get; set; }
        public string? UsuarioAutorizoFirma1 { get; set; }
        public bool? IdAutorizacion2 { get; set; }
        public string? UsuarioAutorizoFirma2 { get; set; }
        public string ModificadoPor { get; set; } = null!;
        public DateTime FechaModificacion { get; set; }
        public string? Destinatario { get; set; }
        public string? Descripcion { get; set; }

    }
}
