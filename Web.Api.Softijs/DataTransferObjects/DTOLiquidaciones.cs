namespace Web.Api.Softijs.DataTransferObjects
{
    public class DTOLiquidaciones
    {
        public int id_liquidaciones { get; set; }
        public DateTime? fecha_liquidacion { get; set; }
        public string? nombre_empleado { get; set; }
        public decimal? monto { get; set; }
        public decimal precio_hora { get; set; }
        public int cant_horas {get; set; }

    }
}
