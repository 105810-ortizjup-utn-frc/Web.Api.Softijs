using Web.Api.Softijs.DataContext;
using Web.Api.Softijs.Models;
using Microsoft.EntityFrameworkCore;
namespace Web.Api.Softijs.Services
{
    public class ServicioProductos : IServicioProductos
    {
        private readonly SoftijsDevContext context;
        public ServicioProductos(SoftijsDevContext _context)
        {
            this.context = _context;
        }

        public List<Producto> GetProductos()
        {
            return context.Productos.AsNoTracking().ToList();
        }
    }
}
