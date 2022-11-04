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
                             ConceptoAbonado = p.IdComprobantePagoNavigation.Descripcion

                         }) ;


            return await query.ToListAsync();

        }
    }
}
