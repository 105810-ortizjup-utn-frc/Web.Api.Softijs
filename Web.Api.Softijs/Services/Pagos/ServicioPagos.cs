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
        private readonly SecurityService _securityService;

        public ServicioPagos(SoftijsDevContext _context, SecurityService securityService)
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
<<<<<<< HEAD
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
            return await context.Liquidaciones.AsNoTracking()
                .Include(x => x.IdUsuarioNavigation)
                .Select<Liquidacione, ComboBoxItemDto>(x => x)
                .ToListAsync();
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
=======
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
                          

            /**
               var query = (from prd in _softijsDevContext.Pedidos.Include(x=>x.DetallesPedidos).AsNoTracking()
                    
                         join cl in _softijsDevContext.Clientes.AsNoTracking() on prd.IdCliente equals cl.IdCliente
                         join vd in _softijsDevContext.Usuarios.AsNoTracking() on prd.IdUsuario equals vd.IdUsuario
                         select new DTOPedidos { 
                             NroPedido = prd.NroPedido,
                             Cliente = $"{cl.Nombre} {cl.Apellido}",
                             Vendedor = $"{vd.Nombre} {vd.Apellido}",
                             Total = prd.DetallesPedidos.Sum(x=>x.Monto*x.Cantidad),
                             Fecha = prd.Fecha
                         });
            return await query.ToListAsync();      
             **/
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

                         }) ;


            return await query.ToListAsync();

>>>>>>> a670494c9944a5cfc28ef53228a7321e9c91dca0
        }
    }
}
