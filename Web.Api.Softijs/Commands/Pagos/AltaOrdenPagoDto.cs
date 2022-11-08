using System.Linq;
using Web.Api.Softijs.Models;

namespace Web.Api.Softijs.Commands.Pagos
{
    public class AltaOrdenPagoDto
    {
        public int IdOrdenPago { get; set; }
        public int IdTipoOrdenPago { get; set; }
        public int IdEstadoOrdenPago { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public List<DetalleOrdenPagoDto> DetallesOrdenPagoDto { get; set; }

        public static implicit operator OrdenesPago(AltaOrdenPagoDto dto)
        {
            return new OrdenesPago
            {
                IdOrdenPago = dto.IdOrdenPago,
                FechaCreacion = dto.FechaCreacion,
                IdEstadoOrdenPago = dto.IdEstadoOrdenPago,
                FechaVencimiento = dto.FechaVencimiento,
                IdTipoOrdenPago = dto.IdTipoOrdenPago,
                DetallesOrdenesPagos = dto.DetallesOrdenPagoDto.Select<DetalleOrdenPagoDto, DetallesOrdenesPago>(x => x).ToList()
            };
        }

        public static implicit operator AltaOrdenPagoDto(OrdenesPago entity)
        {
            return new AltaOrdenPagoDto
            {
                IdOrdenPago = entity.IdOrdenPago,
                FechaCreacion = entity.FechaCreacion,
                IdEstadoOrdenPago = entity.IdEstadoOrdenPago,
                FechaVencimiento = entity.FechaVencimiento,
                IdTipoOrdenPago = entity.IdTipoOrdenPago,
                DetallesOrdenPagoDto = entity.DetallesOrdenesPagos.Select<DetallesOrdenesPago, DetalleOrdenPagoDto>(x => x).ToList(),
            };
        }
    }
}
