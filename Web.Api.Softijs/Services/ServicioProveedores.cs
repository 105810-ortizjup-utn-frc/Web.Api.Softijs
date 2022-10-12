using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Api.Softijs.DataContext;
using Web.Api.Softijs.Models;
using Microsoft.EntityFrameworkCore;

namespace Web.Api.Softijs.Services
{
    class ServicioProveedores : IServicioProveedores
    {
        private readonly SoftijsDevContext context;
        public ServicioProveedores (SoftijsDevContext _context)
        {
            this.context = _context;
        }

        public List<Proveedore> GetProveedores()
        {
            return this.context.Proveedores.AsNoTracking().ToList();
        }
    }
}
