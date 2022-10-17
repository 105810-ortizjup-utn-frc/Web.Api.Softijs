using Microsoft.EntityFrameworkCore;
using Web.Api.Softijs.Commands.Comunes;
using Web.Api.Softijs.DataContext;
using Web.Api.Softijs.Models;

namespace Web.Api.Softijs.Services.Comunes
{
    public class ServicioFormasPagos : IServicioFormasPagos
    {
        private readonly SoftijsDevContext _context;

        public ServicioFormasPagos(SoftijsDevContext context)
        {
            _context = context;
        }

        public async Task<List<ComboBoxItemDto>> GetFormasPagosForComboBox()
        {
            return await _context.FormasPagos.AsNoTracking().Select<FormasPago, ComboBoxItemDto>(x => x).ToListAsync();
        }
    }
}
