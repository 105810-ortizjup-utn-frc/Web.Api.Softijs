using Microsoft.EntityFrameworkCore;
using Web.Api.Softijs.DataContext;
using Web.Api.Softijs.Models;

namespace Web.Api.Softijs.Services
{
    public class ServicioGustos : IServicioGustos
    {
        private readonly SoftijsDevContext context;
        public ServicioGustos(SoftijsDevContext _context)
        {
            this.context = _context;
        }
        public async Task<List<Gusto>> GetGustos()
        {
            return await this.context.Gustos.AsNoTracking().ToListAsync();
        }
    }
}
