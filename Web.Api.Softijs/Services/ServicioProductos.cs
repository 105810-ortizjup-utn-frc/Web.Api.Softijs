using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using Web.Api.Softijs.Commands.Comunes;
using Web.Api.Softijs.Commands.Ventas;
using Web.Api.Softijs.DataContext;
using Web.Api.Softijs.Models;
using Web.Api.Softijs.Results;

namespace Web.Api.Softijs.Services
{
    public class ServicioProductos : IServicioProductos
    {
        private readonly SoftijsDevContext context;

        public ServicioProductos(SoftijsDevContext _context)
        {
            this.context = _context;
        }

        public async Task<InformacionProductoDto> GetInformacionProductoDtoById(int id)
        {
            return await context.Productos
                .AsNoTracking()
                .Include(x => x.IdMarcaNavigation)
                .Include(x => x.IdGustoNavigation)
                .Include(x => x.IdUnidadMedidaNavigation)
                .Include(x => x.IdProveedorNavigation)
                .Include(x => x.IdCategoriaNavigation)
                .FirstOrDefaultAsync(x => x.NroProducto == id);
        }

        public async Task<List<ComboBoxItemDto>> GetProductosForComboBox()
        {
            return await context.Productos.AsNoTracking().Where(x => x.Activo).Select<Producto, ComboBoxItemDto>(x => x).ToListAsync();
        }

        public List<Producto> GetProductos()
        {
            return context.Productos.AsNoTracking().ToList();
        }

        public async Task<ResultadoBase> PostProducto(Producto p)
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
