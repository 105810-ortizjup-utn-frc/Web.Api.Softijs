using Web.Api.Softijs.Models;

namespace Web.Api.Softijs.Commands.Pagos
{
    public class LIquidacionFullDto
    {
        public int IdLiquidacion { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaLiquidacion { get; set; }
        public int CantidadHoraTrabajada { get; set; }
        public decimal MontoPorHora { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string ModificadoPor { get; set; } = null!;
        public DateTime FechaModificacion { get; set; }
        public string CreadoPor { get; set; } = null!;

        public static implicit operator LIquidacionFullDto(Liquidacione entity)
        {
            return new LIquidacionFullDto
            {
                IdLiquidacion = entity.IdLiquidacion,
                IdUsuario = entity.IdUsuario,
                FechaLiquidacion = entity.FechaLiquidacion,
                CantidadHoraTrabajada = entity.CantidadHoraTrabajada,
                MontoPorHora = entity.MontoPorHora,
                CreadoPor = entity.CreadoPor,
                FechaCreacion = entity.FechaCreacion,
                FechaModificacion = entity.FechaModificacion,
                ModificadoPor = entity.ModificadoPor
            };
        }
    }
}
