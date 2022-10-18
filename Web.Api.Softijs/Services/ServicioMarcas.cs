using Microsoft.EntityFrameworkCore;
using Web.Api.Softijs.DataContext;
using Web.Api.Softijs.Models;

namespace Web.Api.Softijs.Services
{
    public class ServicioMarcas : IServicioMarcas
    {
        private readonly SoftijsDevContext context;
        public ServicioMarcas(SoftijsDevContext _context)
        {
            this.context = _context;
        }
        public async Task<List<Marca>> GetMarcas()
        {
            return await context.Marcas.AsNoTracking().ToListAsync();
        }
    }
}
