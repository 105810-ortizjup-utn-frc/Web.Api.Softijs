namespace Web.Api.Softijs.DataTransferObjects
{
    public class DTOReporteLiquidaciones
    {
        public int? id_liquidaciones { get; set; }
        public DateTime? fechaLiquidacion { get; set; }
        public string? empleado { get; set; }
        public decimal? precioHora { get; set; }
        public int? cantHoras { get; set; }
        public string? legajo { get; set; }
        public string? categoria { get; set; }
        public decimal? monto { get; set; }
        public int? cantidad { get; set; }

    }

    public class DTOCantXCat
    {
        
        public string? categoria { get; set; }
        public int? cantidad { get; set; }

    }
}
