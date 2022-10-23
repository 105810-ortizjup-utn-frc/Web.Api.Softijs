using System.ComponentModel.DataAnnotations;
using Web.Api.Softijs.Models;

namespace Web.Api.Softijs.Commands.Ventas
{
    public class PedidoFormaPagoDto
    {
        [Required(ErrorMessage = "Debe seleeccionar al menos una forma de pago.")]
        public int IdFormaPago { get; set; }
        public int IdPedido { get; set; }
        [Required(ErrorMessage = "El monto no puede ser zero o vacio.")]
        public decimal Monto { get; set; }

        public static implicit operator PedidosFormasPago(PedidoFormaPagoDto dto)
        {
            return new PedidosFormasPago
            {
                IdFormaPago = dto.IdFormaPago, 
                IdPedidoFormasPago = dto.IdPedido,
                Monto = dto.Monto
            };
        }

        public static implicit operator PedidoFormaPagoDto(PedidosFormasPago dto)
        {
            return new PedidoFormaPagoDto
            {
                IdFormaPago = dto.IdFormaPago,
                IdPedido = dto.NroPedido,
                Monto = dto.Monto
            };
        }
    }
}
