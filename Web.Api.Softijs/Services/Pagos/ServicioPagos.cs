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
        private readonly ISecurityService securityService;

        public ServicioPagos(SoftijsDevContext _context, ISecurityService securityService)
        {
            this.context = _context;
            _securityService = securityService;
            this.securityService = _securityService;
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

        public async Task<List<DTOComprobanteDePago>> GetComprobantePago()
        {
            //var query = (from p in context.DetallesOrdenesPagos.Include(x => x.IdComprobantePagoNavigation).Include(x => x.IdOrdenPagoNavigation).AsNoTracking()

            //             select new DTOComprobanteDePago
            //             {
            //                 //esta mostrando orden de pago y detalle, no comprobante
            //                 NroOrdenPago = p.IdOrdenPagoNavigation.IdOrdenPago,
            //                 FechaCarga = p.IdComprobantePagoNavigation.FechaCreacion,
            //                 ModificadoPor = p.IdComprobantePagoNavigation.ModificadoPor,
            //                 FechaModificacion = p.IdComprobantePagoNavigation.FechaModificacion,
            //                 CreadoPor = p.IdComprobantePagoNavigation.CreadoPor,
            //                 FechaCreacion = p.IdComprobantePagoNavigation.FechaCreacion,
            //                 MontoAbonado = p.IdOrdenPagoNavigation.DetallesOrdenesPagos.Sum(x => x.Monto ?? 0),
            //                 ConceptoAbonado = p.Descripcion

            //             });

            var query = (from p in context.OrdenesPagos.Include(x => x.DetallesOrdenesPagos).AsNoTracking()
                         join id in context.DetallesOrdenesPagos.AsNoTracking() on p.IdOrdenPago equals id.IdOrdenPago
                         join com in context.ComprobantesPagos.AsNoTracking() on id.IdComprobantePago equals com.IdComprobantePago
                         select new DTOComprobanteDePago
                         {
                             IdComprobante = com.IdComprobantePago,
                             NroOrdenPago = p.IdOrdenPago,
                             FechaCarga = com.FechaCreacion,
                             ModificadoPor = com.ModificadoPor,
                             FechaModificacion = com.FechaModificacion,
                             CreadoPor = com.CreadoPor,
                             FechaCreacion = com.FechaCreacion,
                             MontoAbonado = p.DetallesOrdenesPagos.Sum(x => x.Monto ?? 0),
                             ConceptoAbonado = com.Descripcion
                         });

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

        public async Task<List<DTODetalleOrdenPago>> GetDetallesOrdenesPago(int id)
        {
            var query = (from det in context.DetallesOrdenesPagos.Where(c=>c.IdOrdenPago.Equals(id)).AsNoTracking()
                         join fp in context.FormasPagos.AsNoTracking() on det.IdFormaPago equals fp.IdFormaPago
                         join l in context.Liquidaciones.AsNoTracking() on det.IdLiquidacion equals l.IdLiquidacion into groupLiquidacion
                         from gl in groupLiquidacion.DefaultIfEmpty()
                         join aut in context.Autorizaciones.AsNoTracking() on det.IdAutorizacion1 equals aut.IdAutorizacion into groupAut1
                         from group1 in groupAut1.DefaultIfEmpty()
                         join aut2 in context.Autorizaciones.AsNoTracking() on det.IdAutorizacion2 equals aut2.IdAutorizacion into groupAut2
                         from group2 in groupAut2.DefaultIfEmpty()
                         join us in context.Usuarios.AsNoTracking() on gl.IdUsuario equals us.IdUsuario into groupUsuario
                         from group3 in groupUsuario.DefaultIfEmpty()

                         select new DTODetalleOrdenPago
                         {
                             forma_pago = fp.Descripcion,
                             Monto = det.Monto,
                             destinatario = group3 != null ? $"{group3.Legajo} - {group3.Nombre} {group3.Apellido}" : null,
                             liquidacion = gl != null ? gl.IdLiquidacion : (int?)null,
                             IdAutorizacion1 = group1 != null ? true : false,
                             IdAutorizacion2 = group2 != null ? true : false,
                             ModificadoPor = det.ModificadoPor,
                             FechaModificacion = det.FechaModificacion
                         });

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
            try
            {
                if (orden != null)
                {
                    orden.IdEstadoOrdenPago = p.estado;

                    context.Update(orden);

                    await context.SaveChangesAsync(this.securityService.GetUserName() ?? Constantes.DefaultSecurityValues.DefaultUserName);
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
            catch (Exception ex)
            {
                resultado.Ok = false;
                resultado.CodigoEstado = 400;
                resultado.Error = ex.ToString();
                resultado.Message = "Error al modificar la orden";
            }

            return resultado;
        }

        public async Task<ResultadoBase> AutorizarFirma1(int idDetalleOrdenPago)
        {
            ResultadoBase resultado = new ResultadoBase();
            var det = await context.DetallesOrdenesPagos.Where(c => c.IdDetalleOrdenPago.Equals(idDetalleOrdenPago)).FirstOrDefaultAsync();
            if (det != null)
            {
                if (det.IdFormaPago == 3)
                {
                    det.IdAutorizacion1 = 1;
                    context.Update(det);
                    await context.SaveChangesAsync(securityService.GetUserName() ?? Constantes.DefaultSecurityValues.DefaultUserName);
                    resultado.Ok = true;
                    resultado.CodigoEstado = 200;
                    resultado.Message = "La firma se registró exitosamente";

                }
            }
            else
            {
                resultado.Ok = false;
                resultado.CodigoEstado = 400;
                resultado.Message = "Error al autorizar la firma 1";
            }
            return resultado;
        }

        public async Task<AltaOrdenPagoDto> GetAltaOrdenPagoDtoById(int id)
        {
            return await context.OrdenesPagos.Include(x => x.DetallesOrdenesPagos).AsNoTracking().FirstOrDefaultAsync(x => x.IdOrdenPago == id);
        }

        public async Task<ResultadoBase> AutorizarFirma2(int idDetalleOrdenPago)
        {
            ResultadoBase resultado = new ResultadoBase();
            var det = await context.DetallesOrdenesPagos.Where(c => c.IdDetalleOrdenPago.Equals(idDetalleOrdenPago)).FirstOrDefaultAsync();
            if (det != null)
            {
                if (det.IdFormaPago == 3 && det.Monto > 200000)
                {
                    det.IdAutorizacion2 = 2;
                    context.Update(det);
                    await context.SaveChangesAsync(securityService.GetUserName() ?? Constantes.DefaultSecurityValues.DefaultUserName);
                    resultado.Ok = true;
                    resultado.CodigoEstado = 200;
                    resultado.Message = "La firma se registró exitosamente";

                }
                else
                {
                    resultado.Ok = false;
                    resultado.CodigoEstado = 400;
                    resultado.Message = "Error al autorizar la firma 2";
                }
            }

            return resultado;
        }

        public async Task<List<DTOLiquidaciones>> GetDetallesLiquidaciones()
        {
            var query = (from liq in context.Liquidaciones.AsNoTracking()
                         join us in context.Usuarios.AsNoTracking() on liq.IdUsuario equals us.IdUsuario
                         join dop in context.DetallesOrdenesPagos.AsNoTracking() on liq.IdLiquidacion equals dop.IdLiquidacion


                         select new DTOLiquidaciones
                         {
                             id_liquidaciones = liq.IdLiquidacion,
                             fecha_liquidacion = liq.FechaLiquidacion,
                             nombre_empleado = us.Nombre,
                             monto = dop.Monto,
                             precio_hora = liq.MontoPorHora,
                             cant_horas = liq.CantidadHoraTrabajada
                         });

            return await query.ToListAsync();
        }

        public async Task<DTOLiquidaciones> GetLiquidacionesById(int id)
        {
            try
            {
                Liquidacione liquidacion = await context.Liquidaciones.Where(c => c.IdLiquidacion.Equals(id)).Include(x => x.DetallesOrdenesPagos).Include(x => x.IdUsuarioNavigation).FirstOrDefaultAsync();
                DTOLiquidaciones dto = new DTOLiquidaciones();
                dto.id_liquidaciones = liquidacion.IdLiquidacion;
                dto.fecha_liquidacion = liquidacion.FechaLiquidacion;
                dto.precio_hora = liquidacion.MontoPorHora;
                dto.cant_horas = liquidacion.CantidadHoraTrabajada;
                dto.nombre_empleado = liquidacion.IdUsuarioNavigation.Nombre;
                dto.monto = liquidacion.MontoPorHora * liquidacion.CantidadHoraTrabajada;

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
            try
            {
                if (orden != null)
                {
                    orden.IdEstadoOrdenPago = p.estado;

                    context.Update(orden);

                    await context.SaveChangesAsync(this.securityService.GetUserName() ?? Constantes.DefaultSecurityValues.DefaultUserName);
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
            catch (Exception ex)
            {
                resultado.Ok = false;
                resultado.CodigoEstado = 400;
                resultado.Error = ex.ToString();
                resultado.Message = "Error al modificar la orden";
            }

            return resultado;

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
    }
}
