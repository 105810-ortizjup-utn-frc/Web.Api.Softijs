using Web.Api.Softijs.DataContext;
using Web.Api.Softijs.Models;
using Microsoft.EntityFrameworkCore;
using Web.Api.Softijs.Results;
using Web.Api.Softijs.Commands;

namespace Web.Api.Softijs.Services
{
    public class ServicioProductos : IServicioProductos
    {
        private readonly SoftijsDevContext context;
        public ServicioProductos(SoftijsDevContext _context)
        {
            this.context = _context;
        }

        public List<Producto> GetProductos()
        {
            return context.Productos.AsNoTracking().ToList();
        }

        public async Task<ResultadoBase> PostProducto(Producto  p)
        {
            ResultadoBase resultado = new ResultadoBase();
            try
            {
             
                context.Add(p);
                context.SaveChanges();
                resultado.Ok = true;
                resultado.CodigoEstado = 200;
                return resultado;
            }
            catch (Exception)
            {
                resultado.Ok = false;
                resultado.CodigoEstado = 400;
                resultado.Message = "Error al ingresar un producto";
               return resultado;
            }
        }
    }
}
