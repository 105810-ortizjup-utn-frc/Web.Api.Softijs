using Microsoft.EntityFrameworkCore;
using Web.Api.Softijs.DataContext;
using Web.Api.Softijs.Models;

namespace Web.Api.Softijs.Services
{
    public class ServicioTipoFidelizacion : IServicioTipoFidelizacion
    {
        private readonly SoftijsDevContext _context;
        public ServicioTipoFidelizacion(SoftijsDevContext context)
        {
            _context = context;
        }

        public async Task<List<TiposFidelizacione>> GetTipoFidelizacion()
        {
            return await _context.TiposFidelizaciones.AsNoTracking().ToListAsync();
        }
    }
}
