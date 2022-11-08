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
    }
}
