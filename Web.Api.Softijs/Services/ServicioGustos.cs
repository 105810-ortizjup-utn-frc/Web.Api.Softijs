using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Api.Softijs.DataContext;
using Web.Api.Softijs.Models;

namespace Web.Api.Softijs.Services
{
    public class ServicioGustos : IServicioGustos
    {
        private readonly SoftijsDevContext context;
        public ServicioGustos(SoftijsDevContext _context)
        {
            this.context = _context;
        }
        public List<Gusto> GetGustos()
        {
            return this.context.Gustos.AsNoTracking().ToList();
        }
    }
}
