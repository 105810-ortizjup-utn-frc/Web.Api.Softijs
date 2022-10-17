using Web.Api.Softijs.Models;

namespace Web.Api.Softijs.Commands.Ventas
{
    public class PedidoDto
    {
        public int NroPedido { get; set; }
        public int IdCliente { get; set; }
        public int IdVendedor { get; set; }
        public int? IdFormaPago { get; set; }
        public int? IdEstadoPedido { get; set; }
        public DateTime Fecha { get; set; }

        public List<DetallePedidoDto> DetalleVentasDtos { get; set; }


        public static implicit operator Pedido(PedidoDto? pedidoDto)
        {
            if (pedidoDto == null)
                return pedidoDto;

            return new Pedido
            {
                NroPedido = pedidoDto.NroPedido,
                IdCliente = pedidoDto.IdCliente,
                IdUsuario = pedidoDto.IdVendedor,
                IdEstadoPedido = pedidoDto.IdEstadoPedido,
                IdFormaPago = pedidoDto.IdFormaPago,
                Fecha = pedidoDto.Fecha,
                DetallesPedidos = pedidoDto.DetalleVentasDtos.Select<DetallePedidoDto, DetallesPedido>(x => x).ToList()
            };
        }

        public static implicit operator PedidoDto(Pedido? entity)
        {
            if (entity == null)
                return entity;

            return new PedidoDto
            {
                NroPedido = entity.NroPedido,
                IdCliente = entity.IdCliente,
                IdVendedor = entity.IdUsuario,
                IdFormaPago = entity.IdFormaPago,
                IdEstadoPedido = entity.IdEstadoPedido,
                Fecha = entity.Fecha,
                DetalleVentasDtos = entity.DetallesPedidos.Select<DetallesPedido, DetallePedidoDto>(x => x).ToList()
            };
        }
    }
}
