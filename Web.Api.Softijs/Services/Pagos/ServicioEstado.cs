using Microsoft.EntityFrameworkCore;
using Web.Api.Softijs.DataContext;
using Web.Api.Softijs.Models;

namespace Web.Api.Softijs.Services.Pagos
{
    public class ServicioEstado : IServicioEstadoOP
    {
        private readonly SoftijsDevContext context;

        public ServicioEstado(SoftijsDevContext _context)
        {
            this.context = _context;
        }

        public async Task<List<EstadosOrdenesPago>> GetEstado()
        {
            return await context.EstadosOrdenesPagos.AsNoTracking().ToListAsync();
        }
    }
}
