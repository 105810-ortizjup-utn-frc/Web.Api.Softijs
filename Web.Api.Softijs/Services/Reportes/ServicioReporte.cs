using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using RazorLight.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.Arm;
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

            var query = _context.Pedidos.Where(c=>c.IdUsuario.Equals(id) && c.Fecha.Month.Equals(DateTime.Now.Month)).Include(x => x.IdUsuarioNavigation).GroupBy(x => new { x.Fecha, x.IdUsuarioNavigation.Nombre }).
                Select(x => new DTORendimientoVendedor
                {
                    fecha = x.Key.Fecha.ToString("MMMM dd"),
                    nombre = x.Key.Nombre,
                    cantidadVentas = x.Select(y => y.IdUsuario).Count()
                }).ToList();


            return query;
        }

       public async Task<List<DTORendimientoVendedor>> GetMontoTotal(int id)
        {

            
            var query = _context.Pedidos.Where(c => c.IdUsuario.Equals(id) && c.Fecha.Year.Equals(DateTime.Now.Year)).Include(x => x.IdUsuarioNavigation)
                        .Include(x=>x.DetallesPedidos).GroupBy(x => new { x.Fecha.Month, x.IdUsuarioNavigation.Nombre }).
                        Select(x => new DTORendimientoVendedor
                        {
                    fecha = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(x.Key.Month).FirstLetterToUpperCase(),
                    nombre = x.Key.Nombre,
                    cantidadVentas = x.SelectMany(x=>x.DetallesPedidos).Sum(y=>y.Cantidad*y.PrecioUnitario)
                }).ToList();


            return query;
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
                            Cantidad = g.Select(x=>x.Cantidad).Sum()
                        });

            return query.ToList();
        }
    }
}
