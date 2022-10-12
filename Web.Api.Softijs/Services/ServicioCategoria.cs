using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Api.Softijs.DataContext;
using Web.Api.Softijs.Models;
using Microsoft.EntityFrameworkCore;

namespace Web.Api.Softijs.Services
{
    public class ServicioCategoria : IServicioCategoria
    {
        private readonly SoftijsDevContext context;
        public ServicioCategoria(SoftijsDevContext _context)
        {
            this.context = _context;
        }

        public List<Categoria> GetCategorias()
        {
            return this.context.Categorias.AsNoTracking().ToList();
        }
    }
}
