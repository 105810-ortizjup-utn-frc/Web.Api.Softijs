namespace Web.Api.Softijs.Comun.PDF.Models
{
    public class PedidoFormaPagoProducto
    {
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal SubTotal => PrecioUnitario * Cantidad;
    }
}
