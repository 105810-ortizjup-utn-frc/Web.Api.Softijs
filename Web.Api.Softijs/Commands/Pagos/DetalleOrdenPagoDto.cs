using Web.Api.Softijs.Models;

namespace Web.Api.Softijs.Commands.Pagos
{
    public class DetalleOrdenPagoDto
    {
        public int IdDetalleOrdenPago { get; set; }
        public int? IdProveedor { get; set; }
        public int? IdOrdenPago { get; set; }
        public int IdFormaPago { get; set; }
        public int? IdLiquidacion { get; set; }
        public int? IdComproabnte { get; set; }
        public decimal? Monto { get; set; }
        public string Concepto { get; set; } 
        public int? IdAutorizacion1 { get; set; }
        public int? IdAutorizacion2 { get; set; }

        public static implicit operator DetallesOrdenesPago(DetalleOrdenPagoDto dto)
        {
            return new DetallesOrdenesPago
            {
                IdDetalleOrdenPago = dto.IdDetalleOrdenPago,
                IdProveedor = dto.IdProveedor,
                IdOrdenPago = dto.IdOrdenPago,
                IdFormaPago = dto.IdFormaPago,
                IdLiquidacion = dto.IdLiquidacion,
                IdComprobantePago = dto.IdComproabnte,
                IdAutorizacion1 = dto.IdAutorizacion1,
                IdAutorizacion2 = dto.IdAutorizacion2,
                Monto = dto.Monto,
                Descripcion = dto.Concepto
            };
        }

        public static implicit operator DetalleOrdenPagoDto(DetallesOrdenesPago entity)
        {
            return new DetallesOrdenesPago
            {
                IdDetalleOrdenPago = entity.IdDetalleOrdenPago,
                IdProveedor = entity.IdProveedor,
                IdOrdenPago = entity.IdOrdenPago,
                IdFormaPago = entity.IdFormaPago,
                IdLiquidacion = entity.IdLiquidacion,
                IdComprobantePago = entity.IdComprobantePago,
                IdAutorizacion1 = entity.IdAutorizacion1,
                IdAutorizacion2 = entity.IdAutorizacion2,
                Monto = entity.Monto,
                Descripcion = entity.Descripcion
            };
        }
    }
}
