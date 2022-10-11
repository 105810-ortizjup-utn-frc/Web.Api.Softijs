using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Api.Softijs.DataContext;
using Web.Api.Softijs.Models;
using Microsoft.EntityFrameworkCore;

namespace Web.Api.Softijs.Services
{
    class ServicioUnidadesMedida : IServicioUnidadesMedidas
    {
        private readonly SoftijsDevContext context;
        public ServicioUnidadesMedida(SoftijsDevContext _context)
        {
            this.context = _context;
        }
        public List<UnidadesMedida> GetUnidadesMedida()
        {
            return this.context.UnidadesMedidas.AsNoTracking().ToList();
        }
    }
}
