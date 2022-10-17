using Microsoft.EntityFrameworkCore;
using Web.Api.Softijs.Commands.Comunes;
using Web.Api.Softijs.DataContext;
using Web.Api.Softijs.Models;

namespace Web.Api.Softijs.Services.Comunes
{
    public class ServicioUsuarios : IServicioUsuarios
    {
        private readonly SoftijsDevContext _context;

        public ServicioUsuarios(SoftijsDevContext context)
        {
            _context = context;
        }

        public async Task<List<ComboBoxItemDto>> GetUsuariosForComboBox()
        {
            return await _context.Usuarios.AsNoTracking().Where(x => x.Activo).Select<Usuario, ComboBoxItemDto>(x => x).ToListAsync();
        }
    }
}
