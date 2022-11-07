using Microsoft.EntityFrameworkCore;
using Web.Api.Softijs.Commands.Comunes;
using Web.Api.Softijs.Commands.Pagos;
using Web.Api.Softijs.Comun;
using Web.Api.Softijs.DataContext;
using Web.Api.Softijs.DataTransferObjects;
using Web.Api.Softijs.Models;
using Web.Api.Softijs.Results;
using Web.Api.Softijs.Services.Security;

namespace Web.Api.Softijs.Services.Pagos
{
    public class ServicioPagos : IServicioPagos
    {

        private readonly SoftijsDevContext context;
        private readonly ISecurityService _securityService;

        public ServicioPagos(SoftijsDevContext _context, ISecurityService securityService)
        {
            this.context = _context;
            _securityService = securityService;
        }

        public async Task<List<DTOordenP>> GetOrdenP()
        {
            return await (from prd in context.OrdenesPagos.Include(x => x.DetallesOrdenesPagos).AsNoTracking()

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

                          }).ToListAsync();
        }

        public async Task<List<DTOPagosPendientes>> GetPagosPendientes()
        {
            return await (from p in context.OrdenesPagos.Include(x => x.DetallesOrdenesPagos).AsNoTracking()
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
                          }).ToListAsync();
        }

        public async Task<List<ComboBoxItemDto>> GetProveedoresForComboBox()
        {
            return await context.Proveedores.AsNoTracking()
                .Select<Proveedore, ComboBoxItemDto>(x => x)
                .ToListAsync();
        }

        public async Task<List<ComboBoxItemDto>> GetLiquidacionForComboBox()
        {
            var alreadyPaid = await context.DetallesOrdenesPagos.Include(x => x.IdLiquidacionNavigation).AsNoTracking().Select(s => s.IdLiquidacion).ToListAsync();
            var all = await context.Liquidaciones.AsNoTracking().Select(x => x.IdLiquidacion).ToListAsync();
            var currents = all.Where(x => !alreadyPaid.Contains(x)).ToList();

            return await context.Liquidaciones.AsNoTracking()
                .Include(x => x.IdUsuarioNavigation)
                .Where(x => currents.Contains(x.IdLiquidacion))
                .Select<Liquidacione, ComboBoxItemDto>(x => x)
                .ToListAsync();
        }

        public async Task<List<LIquidacionFullDto>> GetLiquidacionForList()
        {
            var alreadyPaid = await context.DetallesOrdenesPagos.Include(x => x.IdLiquidacionNavigation).AsNoTracking().Select(s => s.IdLiquidacion).ToListAsync();
            var all = await context.Liquidaciones.AsNoTracking().Select(x => x.IdLiquidacion).ToListAsync();
            var currents = all.Where(x => !alreadyPaid.Contains(x)).ToList();

            return await context.Liquidaciones.AsNoTracking()
                .Include(x => x.IdUsuarioNavigation)
                .Where(x => currents.Contains(x.IdLiquidacion))
                .Select<Liquidacione, LIquidacionFullDto>(x => x)
                .ToListAsync();
        }

        public async Task<List<ComboBoxItemDto>> GetFormasDePagosForComboBoxItem()
        {
            return await context.FormasPagos.AsNoTracking().Select<FormasPago, ComboBoxItemDto>(x => x).ToListAsync();
        }

        public async Task<ResultadoBase> SaveOrdenPago(OrdenesPago entity)
        {
            try
            {
                if (entity.IdOrdenPago != 0)
                {
                    context.OrdenesPagos.Update(entity);
                }
                else
                {
                    await context.OrdenesPagos.AddAsync(entity);
                }

                await context.SaveChangesAsync(_securityService.GetUserName() ?? Constantes.DefaultSecurityValues.DefaultUserName);

                return new ResultadoBase { Ok = true, CodigoEstado = 200, Error = string.Empty, Message = "La orden de pago se guardo correctamente." };
            }
            catch (Exception ex)
            {
                return new ResultadoBase { Ok = false, CodigoEstado = 500, Error = ex.Message };
            }
        }

        public async Task<AltaOrdenPagoDto> GetAltaOrdenPagoDtoById(int id)
        {
            return await context.OrdenesPagos.Include(x => x.DetallesOrdenesPagos).AsNoTracking().FirstOrDefaultAsync(x => x.IdOrdenPago == id);
        }

        public async Task<List<DTOComprobanteDePago>> GetComprobantePago()
        {
            var query = (from p in context.DetallesOrdenesPagos.Include(x => x.IdComprobantePagoNavigation).Include(x => x.IdOrdenPagoNavigation).AsNoTracking()

                         select new DTOComprobanteDePago
                         {
                             NroOrdenPago = p.IdOrdenPagoNavigation.IdOrdenPago,
                             FechaCarga = p.IdComprobantePagoNavigation.FechaCreacion,
                             ModificadoPor = p.IdComprobantePagoNavigation.ModificadoPor,
                             FechaModificacion = p.IdComprobantePagoNavigation.FechaModificacion,
                             CreadoPor = p.IdComprobantePagoNavigation.CreadoPor,
                             FechaCreacion = p.IdComprobantePagoNavigation.FechaCreacion,
                             MontoAbonado = p.IdOrdenPagoNavigation.DetallesOrdenesPagos.Sum(x => x.Monto ?? 0),
                             ConceptoAbonado = p.Descripcion

                         });


            return await query.ToListAsync();
        }
    }
}
