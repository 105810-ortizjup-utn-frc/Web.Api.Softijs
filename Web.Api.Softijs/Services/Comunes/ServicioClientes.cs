using Microsoft.EntityFrameworkCore;
using Web.Api.Softijs.Commands.Comunes;
using Web.Api.Softijs.DataContext;
using Web.Api.Softijs.Models;

namespace Web.Api.Softijs.Services.Comunes
{
    public class ServicioClientes : IServicioClientes
    {
        private readonly SoftijsDevContext _context;

        public ServicioClientes(SoftijsDevContext context)
        {
            _context = context;
        }

        public async Task<List<ComboBoxItemDto>> GetClientesForComboBox()
        {
            return await _context.Clientes.AsNoTracking().Where(x => x.Activado).Select<Cliente, ComboBoxItemDto>(x => x).ToListAsync();
        }
    }
}
