using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Api.Softijs.DataContext;
using Web.Api.Softijs.Models;
using Microsoft.EntityFrameworkCore;

namespace Web.Api.Softijs.Services
{
    public class ServicioMarcas : IServicioMarcas
    {
        private readonly SoftijsDevContext context;
        public ServicioMarcas(SoftijsDevContext _context)
        {
            this.context = _context;
        }
        public List<Marca> GetMarcas()
        {
            return context.Marcas.AsNoTracking().ToList();
        }
    }
}
