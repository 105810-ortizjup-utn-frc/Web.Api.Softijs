using Microsoft.EntityFrameworkCore;
using Web.Api.Softijs.DataContext;
using Web.Api.Softijs.DataTransferObjects;
using Web.Api.Softijs.Models;
using Web.Api.Softijs.Services.Security;

namespace Web.Api.Softijs.Services.Pagos
{
    public class ServicioPagos : IServicioPagos
    {

        private readonly SoftijsDevContext context;
        private readonly ISecurityService securityService;
        public ServicioPagos(SoftijsDevContext _context, ISecurityService securityService)
        {
            this.context = _context;
            this.securityService = securityService;
        }

        public async Task<List<DTOordenP>> GetOrdenP()
        {
            var query = (from prd in context.OrdenesPagos.Include(x => x.DetallesOrdenesPagos).AsNoTracking()

                         join tipo in context.TiposOrdenesPagos.AsNoTracking() on prd.IdTipoOrdenPago equals tipo.IdTipoOrdenPago
                         join estado in context.EstadosOrdenesPagos.AsNoTracking() on prd.IdEstadoOrdenPago equals estado.IdEstadoOrdenPago
                         select new DTOordenP
                         {
                             NroOrden = prd.IdOrdenPago,
                             Tipo = tipo.Descripcion,
                             Estado = estado.Descripcion,
                             Fecha = prd.FechaVencimiento,
                             CreadoPor = prd.CreadoPor,
                             FechaCreacion = prd.FechaCreacion,
                             Total = prd.DetallesOrdenesPagos.Sum(x => x.Monto ?? 0)

                         });
            return await query.ToListAsync();
        }

        public async Task<List<DTOPagosPendientes>> GetPagosPendientes()
        {
            var query = (from p in context.OrdenesPagos.Include(x => x.DetallesOrdenesPagos).AsNoTracking()
                         where p.FechaVencimiento >= DateTime.Now.AddDays(-15)
                         select new DTOPagosPendientes
                         {
                             NroOrdenPago = p.IdOrdenPago,
                             FechaVencimiento = p.FechaVencimiento,
                             ModificadoPor = p.ModificadoPor,
                             FechaModificacion = p.FechaModificacion,
                             CreadoPor = p.CreadoPor,
                             FechaCreacion = p.FechaCreacion,
                             Monto = p.DetallesOrdenesPagos.Sum(x => x.Monto ?? 0)
                         }); ;
            return await query.ToListAsync();           
                          

        }

        public async Task<List<DTOComprobanteDePago>> GetComprobantePago()
        {
            var query = (from p in context.DetallesOrdenesPagos.Include(x => x.IdComprobantePagoNavigation).Include(x => x.IdOrdenPagoNavigation).AsNoTracking()

                         select new DTOComprobanteDePago
                         {
                             IdComprobante=p.IdComprobantePago,
                             NroOrdenPago = p.IdOrdenPagoNavigation.IdOrdenPago,
                             FechaCarga = p.IdComprobantePagoNavigation.FechaCreacion,
                             ModificadoPor = p.IdComprobantePagoNavigation.ModificadoPor,
                             FechaModificacion = p.IdComprobantePagoNavigation.FechaModificacion,
                             CreadoPor = p.IdComprobantePagoNavigation.CreadoPor,
                             FechaCreacion = p.IdComprobantePagoNavigation.FechaCreacion,
                             MontoAbonado = p.IdOrdenPagoNavigation.DetallesOrdenesPagos.Sum(x => x.Monto ?? 0),
                             ConceptoAbonado = p.Descripcion

                         }) ;
            return await query.ToListAsync();
        }

        public async Task<DTOComprobanteDePago> GetComprobanteById(int id)
        {
            try
            {
                ComprobantesPago Comprobante = await context.ComprobantesPagos.Where(c => c.IdComprobantePago.Equals(id)).FirstOrDefaultAsync();
                DTOComprobanteDePago dto = new DTOComprobanteDePago();
                dto.IdComprobante = Comprobante.IdComprobantePago;
                dto.NroOrdenPago = Comprobante.NroComprobante;
                dto.ConceptoAbonado = Comprobante.Descripcion;

                return dto;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
