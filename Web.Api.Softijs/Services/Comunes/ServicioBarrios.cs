using Microsoft.EntityFrameworkCore;
using Web.Api.Softijs.Commands.Comunes;
using Web.Api.Softijs.DataContext;
using Web.Api.Softijs.Models;

namespace Web.Api.Softijs.Services.Comunes
{
    public class ServicioBarrios : IServicioBarrios
    {
        private readonly SoftijsDevContext _context;
        public ServicioBarrios(SoftijsDevContext context)
        {
            _context = context;
        }

        public async Task<List<Barrio>> GetBarrios()
        {
            return await _context.Barrios.AsNoTracking().ToListAsync();
        }

        public async Task<List<Ciudade>> GetCiudades()
        {
            return await _context.Ciudades.AsNoTracking().ToListAsync();
        }

        public async Task<List<Provincia>> GetProvincias()
        {
            return await _context.Provincias.AsNoTracking().ToListAsync();
        }
    }
}
