using Web.Api.Softijs.Models;

namespace Web.Api.Softijs.Commands.Ventas
{
    public class DetallePedidoDto
    {
        public int NroDetallePedido { get; set; }
        public int Nro_Pedido { get; set; }
        public int Cantidad { get; set; }
        public int IdProducto { get; set; }
        public decimal PrecioUnitario { get; set; }


        public static implicit operator DetallesPedido(DetallePedidoDto? detallePedidoDto)
        {
            if (detallePedidoDto == null)
                return detallePedidoDto;

            return new DetallesPedido
            {
                NroDetallePedido = detallePedidoDto.NroDetallePedido,
                NroPedido = detallePedidoDto.Nro_Pedido,
                NroProducto = detallePedidoDto.IdProducto,
                Cantidad = detallePedidoDto.Cantidad,
                PrecioUnitario = detallePedidoDto.PrecioUnitario
            };
        }

        public static implicit operator DetallePedidoDto(DetallesPedido? entity)
        {
            if (entity == null)
                return entity;

            return new DetallePedidoDto
            {
                NroDetallePedido = entity.NroDetallePedido,
                Nro_Pedido = entity.NroPedido,
                IdProducto = entity.NroProducto,
                Cantidad = entity.Cantidad,
                PrecioUnitario = entity.PrecioUnitario
            };
        }
    }
}
