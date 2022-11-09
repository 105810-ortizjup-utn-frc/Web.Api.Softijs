using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Web.Api.Softijs.Comun.Extensiones;
using Web.Api.Softijs.DataContext;
using Web.Api.Softijs.DataTransferObjects;
using Web.Api.Softijs.Models;

namespace Web.Api.Softijs.Services.Reportes
{
    class ServicioReporte : IServicioReportes
    {
        private readonly SoftijsDevContext _context;
        public ServicioReporte(SoftijsDevContext context)
        {
            _context = context;
        }

        public async Task<List<DTORendimientoVendedor>> GetRedimientoVendedor(int id)
        {

            var query = _context.Pedidos.Where(c => c.IdUsuario.Equals(id) && c.Fecha.Month.Equals(DateTime.Now.Month)).Include(x => x.IdUsuarioNavigation).GroupBy(x => new { x.Fecha, x.IdUsuarioNavigation.Nombre }).
                Select(x => new DTORendimientoVendedor
                {
                    fecha = x.Key.Fecha.ToString("MMMM dd").FirstLetterToUpperCase(),
                    nombre = x.Key.Nombre,
                    cantidadVentas = x.Select(y => y.IdUsuario).Count()
                }).ToList();


            return query;
        }

        public async Task<List<DTORendimientoVendedor>> GetMontoTotal(int id)
        {


            var query = _context.Pedidos.Where(c => c.IdUsuario.Equals(id) && c.Fecha.Year.Equals(DateTime.Now.Year)).Include(x => x.IdUsuarioNavigation)
                        .Include(x => x.DetallesPedidos).GroupBy(x => new { x.Fecha.Month, x.IdUsuarioNavigation.Nombre }).
                        Select(x => new DTORendimientoVendedor
                        {
                            fecha = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(x.Key.Month).FirstLetterToUpperCase(),
                            nombre = x.Key.Nombre,
                            cantidadVentas = x.SelectMany(x => x.DetallesPedidos).Sum(y => y.Cantidad * y.PrecioUnitario)
                        }).ToList();


            return query;
        }


        public async Task<List<DTOFacturacionDiaria>> GetTotalVendidoDiario()
        {

          
            var query = _context.Pedidos.Where(c => c.Fecha.Month.Equals(DateTime.Now.Month) && c.Fecha.Year.Equals(DateTime.Now.Year)).Include(x => x.IdUsuarioNavigation)
                        .Include(x => x.DetallesPedidos).GroupBy(x => new { x.Fecha}).
                        Select(x => new DTOFacturacionDiaria
                        {
                            dia = x.Key.Fecha.ToString("dddd", new CultureInfo("es-ES")).FirstLetterToUpperCase() +" "+ x.Key.Fecha.Day,
                            montoVendido = x.SelectMany(x => x.DetallesPedidos).Sum(y => y.Cantidad * y.PrecioUnitario)
                        }).ToList();


            return query;
        }

        public async Task<List<DTOReporteLiquidaciones>> GetLiquidacionesEmpleados()
        {
            var query = (from l in _context.Liquidaciones
                         join u in _context.Usuarios.AsNoTracking() on l.IdUsuario equals u.IdUsuario
                         join tu in _context.TiposUsuarios.AsNoTracking() on u.IdTipoUsuario equals tu.IdTipoUsuario
                         select new {l.IdLiquidacion, l.FechaLiquidacion, u.Legajo, Empleado = u.Apellido + ", " + u.Nombre, tu.Descripcion, l.CantidadHoraTrabajada, l.MontoPorHora, TotalLiquidacion = l.CantidadHoraTrabajada * l.MontoPorHora})
                         .Select(g => new DTOReporteLiquidaciones
                        {
                            id_liquidaciones = g.IdLiquidacion,
                            fechaLiquidacion = g.FechaLiquidacion,
                            empleado = g.Empleado,
                            monto = g.TotalLiquidacion,
                            precioHora = g.MontoPorHora,
                            cantHoras = g.CantidadHoraTrabajada,
                            legajo = g.Legajo,
                            categoria = g.Descripcion
                        });

            return query.ToList();
        }

        public async Task<List<DTOCantXCat>> GetCantXCat()
        {
            var query = (from l in _context.Liquidaciones
                         join u in _context.Usuarios.AsNoTracking() on l.IdUsuario equals u.IdUsuario
                         join tu in _context.TiposUsuarios.AsNoTracking() on u.IdTipoUsuario equals tu.IdTipoUsuario
                         select new { l.IdLiquidacion, l.IdUsuario, u.IdTipoUsuario, Categoria = tu.Descripcion })
                        .GroupBy(o => new { o.Categoria })
                        .Select(g => new DTOCantXCat
                        {
                            categoria = g.Key.Categoria,
                            cantidad = g.Select(x=>x.Categoria).Count()
                        });

            return query.ToList();
        }

        public async Task<List<DTOEstadisticaClientes>> GetEstadisticaClientes()
        {
            var query = (from p in _context.Pedidos.Where(c => c.Fecha.Month.Equals(DateTime.Now.Month - 1) && c.Fecha.Year.Equals(DateTime.Now.Year))
                         join dp in _context.DetallesPedidos.AsNoTracking() on p.NroPedido equals dp.NroPedido
                         join prod in _context.Productos.AsNoTracking() on dp.NroProducto equals prod.NroProducto
                         join cl in _context.Clientes.AsNoTracking() on p.IdCliente equals cl.IdCliente
                         join ic in _context.InformacionesContactos.AsNoTracking() on cl.IdInformacionContacto equals ic.IdInformacionContacto
                         select new { p.IdCliente, cl.Nombre, cl.Apellido, ic.Telefono, ic.Celular, ic.Email, Producto = prod.Nombre, dp.Cantidad })
                        .GroupBy(o => new { o.IdCliente, o.Nombre, o.Apellido, o.Telefono, o.Celular, o.Email, o.Producto })
                        .Select(g => new DTOEstadisticaClientes
                        {
                            IdCliente = g.Key.IdCliente,
                            Nombre = g.Key.Nombre,
                            Apellido = g.Key.Apellido,
                            Telefono = g.Key.Telefono,
                            Celular = g.Key.Celular,
                            Email = g.Key.Email,
                            Producto = g.Key.Producto,
                            Cantidad = g.Select(x => x.Cantidad).Sum()
                        });

            return query.ToList();
        }
    }
}
