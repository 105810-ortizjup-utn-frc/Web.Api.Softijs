namespace Web.Api.Softijs.DataTransferObjects
{
    public class DTOComprobanteDePago
    {
        
        public int IdComprobante { set; get; }
        public DateTime FechaCarga { set; get; }
        public decimal MontoAbonado { set; get; }
        public string? ConceptoAbonado { get; set; }
        public string? CreadoPor { set; get; }
        public DateTime FechaCreacion { set; get; }
        public string? ModificadoPor { set; get; }
        public DateTime FechaModificacion { set; get; }
        public int NroOrdenPago { get; set; }

    }
}
