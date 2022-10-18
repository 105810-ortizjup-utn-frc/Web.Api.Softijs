using Microsoft.EntityFrameworkCore;
using Web.Api.Softijs.DataContext;
using Web.Api.Softijs.Models;

namespace Web.Api.Softijs.Services
{
    public class ServicioCategoria : IServicioCategoria
    {
        private readonly SoftijsDevContext context;
        public ServicioCategoria(SoftijsDevContext _context)
        {
            this.context = _context;
        }

        public async Task<List<Categoria>> GetCategorias()
        {
            return await this.context.Categorias.AsNoTracking().ToListAsync();
        }
    }
}
