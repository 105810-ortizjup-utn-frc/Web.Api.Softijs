using Web.Api.Softijs.Models;

namespace Web.Api.Softijs.DataTransferObjects
{
    public class DTODetallePedido
    {
        public int nroDetalle { set; get; }
        public string? Producto { set; get; }
        public string? UnidadMedidad { get; set; }
        public decimal Monto { set; get; }
        public int Cantidad { set; get; }

        public static implicit operator DTODetallePedido(DetallesPedido? entity)
        {
            return new DTODetallePedido
            {
                nroDetalle = entity?.NroDetallePedido ?? 0,
                Producto = entity?.NroProductoNavigation?.Nombre,
                UnidadMedidad = entity?.NroProductoNavigation?.IdUnidadMedidaNavigation?.Descripcion,
                Cantidad = entity?.Cantidad ?? 0,
                Monto = entity?.PrecioUnitario ?? 0
            };
        }
    }
}
