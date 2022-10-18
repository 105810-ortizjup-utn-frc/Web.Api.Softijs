using Microsoft.EntityFrameworkCore;
using Web.Api.Softijs.DataContext;
using Web.Api.Softijs.Models;

namespace Web.Api.Softijs.Services
{
    class ServicioUnidadesMedida : IServicioUnidadesMedidas
    {
        private readonly SoftijsDevContext context;
        public ServicioUnidadesMedida(SoftijsDevContext _context)
        {
            this.context = _context;
        }
        public async Task<List<UnidadesMedida>> GetUnidadesMedida()
        {
            return await this.context.UnidadesMedidas.AsNoTracking().ToListAsync();
        }
    }
}
