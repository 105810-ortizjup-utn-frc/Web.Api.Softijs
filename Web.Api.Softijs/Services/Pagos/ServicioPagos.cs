using Microsoft.EntityFrameworkCore;
using Web.Api.Softijs.DataContext;
using Web.Api.Softijs.DataTransferObjects;
using Web.Api.Softijs.Models;

namespace Web.Api.Softijs.Services.Pagos
{
    public class ServicioPagos : IServicioPagos
    {
        
        private readonly SoftijsDevContext context;

        public ServicioPagos(SoftijsDevContext _context)
        {
            this.context = _context;
        }

        public async Task<List<OrdenesPago>> GetOrdenP()
        {
            return await context.OrdenesPagos.AsNoTracking().ToListAsync();
        }

        public async Task<List<DTOPagosPendientes>> GetPagosPendientes()
        {
            return await context.OrdenesPagos.Include(x => x.DetallesOrdenesPagos).
                Include(x => x.IdEstadoOrdenPagoNavigation).AsNoTracking().
                Where(p => p.FechaVencimiento >= DateTime.Now.AddDays(-15) && p.IdEstadoOrdenPagoNavigation.Descripcion.Equals("Pendiente")).
                Select(p=> new DTOPagosPendientes
                {
                    NroOrdenPago = p.IdOrdenPago,
                    FechaVencimiento = p.FechaVencimiento,
                    ModificadoPor = p.ModificadoPor,
                    FechaModificacion = p.FechaModificacion,
                    CreadoPor = p.CreadoPor,
                    FechaCreacion = p.FechaCreacion,
                    Monto = p.DetallesOrdenesPagos.Sum(x => x.Monto ?? 0)
                }).
                ToListAsync();              
        }
    }
}
