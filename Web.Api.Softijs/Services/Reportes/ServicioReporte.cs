using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

       async Task<List<DTORendimientoVendedor>> IServicioReportes.GetRedimientoVendedor(int id)
        {

            var query = _context.Pedidos.Where(c=>c.IdUsuario.Equals(id)).Include(x => x.IdUsuarioNavigation).GroupBy(x => new { x.Fecha, x.IdUsuarioNavigation.Nombre }).
                Select(x => new DTORendimientoVendedor
                {
                    fecha = x.Key.Fecha,
                    nombre = x.Key.Nombre,
                    cantidadVentas = x.Select(y => y.IdUsuario).Count()
                }).ToList();


            return query;
        }
    }
}
