using Microsoft.EntityFrameworkCore;
using Web.Api.Softijs.Commands.Comunes;
using Web.Api.Softijs.DataContext;
using Web.Api.Softijs.Models;

namespace Web.Api.Softijs.Services.Ventas
{
    public class ServicioEstadosPedidos : IServicioEstadosPedidos
    {
        private readonly SoftijsDevContext _context;

        public ServicioEstadosPedidos(SoftijsDevContext context)
        {
            _context = context;
        }

        public async Task<List<ComboBoxItemDto>> GetEstadosPedidosForComboBox()
        {
            return await _context.EstadosPedidos.AsNoTracking().Select<EstadosPedido, ComboBoxItemDto>(x => x).ToListAsync();
        }
    }
}
