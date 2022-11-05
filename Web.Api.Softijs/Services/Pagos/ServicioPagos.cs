using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
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
        private readonly ISecurityService securityService;
        public ServicioPagos(SoftijsDevContext _context, ISecurityService _securityService)
        {
            this.context = _context;
            this.securityService = _securityService;
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

        }

        public async Task<DTOestadoOP> GetOrdenPagoById(int id)
        {
            try
            {
                OrdenesPago orden = await context.OrdenesPagos.Where(c => c.IdOrdenPago.Equals(id)).FirstOrDefaultAsync();
                DTOestadoOP dto = new DTOestadoOP();

                dto.nroOrden = orden.IdOrdenPago;
                dto.estado = orden.IdEstadoOrdenPago;

                return dto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ResultadoBase> PutOrden(DTOestadoOP p)
        {
            ResultadoBase resultado = new ResultadoBase();
            var orden = await context.OrdenesPagos.Where(c => c.IdOrdenPago.Equals(p.nroOrden)).FirstOrDefaultAsync();
            try {
            if (orden != null)
            {
                orden.IdEstadoOrdenPago = p.estado;

                context.Update(orden);

                await context.SaveChangesAsync(this.securityService.GetUserName()?? Constantes.DefaultSecurityValues.DefaultUserName);
                resultado.Ok = true;
                resultado.CodigoEstado = 200;
                resultado.Message = "La orden se modifico exitosamente.";
            }

            else
            {
                resultado.Ok = false;
                resultado.CodigoEstado = 400;
                resultado.Message = "Error al modificar la orden";
            }
            }
            catch(Exception ex) {
                resultado.Ok = false;
                resultado.CodigoEstado = 400;
                resultado.Error = ex.ToString();
                resultado.Message = "Error al modificar la orden";
            }

            return resultado;

        }


    }
}
