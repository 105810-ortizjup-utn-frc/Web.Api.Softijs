using Microsoft.EntityFrameworkCore;
using Web.Api.Softijs.Commands.Comunes;
using Web.Api.Softijs.DataContext;
using Web.Api.Softijs.Models;

namespace Web.Api.Softijs.Services.Comunes
{
    public class LocationService : ILocationService
    {
        private readonly SoftijsDevContext _context;

        public LocationService(SoftijsDevContext context)
        {
            _context = context;
        }

        public async Task<List<ComboBoxItemDto>> GetBarriosForComboBox()
        {
            return await _context.Barrios.AsNoTracking().Select<Barrio, ComboBoxItemDto>(x => x).ToListAsync();
        }

        public async Task<List<ComboBoxItemDto>> GetProvinciasForComboBox()
        {
            return await _context.Provincias.AsNoTracking().Select<Provincia, ComboBoxItemDto>(x => x).ToListAsync();
        }

        public async Task<List<ComboBoxItemDto>> GetCiudadesForComboBox()
        {
            return await _context.Ciudades.AsNoTracking().Select<Ciudade, ComboBoxItemDto>(x => x).ToListAsync();
        }
    }
}
