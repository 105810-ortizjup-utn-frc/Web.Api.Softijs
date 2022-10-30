using Microsoft.EntityFrameworkCore;
using Web.Api.Softijs.DataContext;
using Web.Api.Softijs.DataTransferObjects;
using Web.Api.Softijs.Models;

namespace Web.Api.Softijs.Services.Pagos
{
    public class ServicioPagos : IServicioPagos
    {

        private readonly SoftijsDevContext context;

        public ServicioPagos(SoftijsDevContext _context)
        {
            this.context = _context;
        }

        public async Task<List<OrdenesPago>> GetOrdenP()
        {
            return await context.OrdenesPagos.AsNoTracking().ToListAsync();
        }

        Task<List<DTOPagosPendientes>> GetPagosPendientes()
        {
            throw new NotImplementedException();
        }
    }
}
