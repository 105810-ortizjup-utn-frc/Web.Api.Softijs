using Microsoft.EntityFrameworkCore;
using Web.Api.Softijs.DataContext;
using Web.Api.Softijs.Models;

namespace Web.Api.Softijs.Services
{
    class ServicioProveedores : IServicioProveedores
    {
        private readonly SoftijsDevContext context;
        public ServicioProveedores(SoftijsDevContext _context)
        {
            this.context = _context;
        }

        public async Task<List<Proveedore>> GetProveedores()
        {
            return await this.context.Proveedores.AsNoTracking().ToListAsync();
        }
    }
}
