using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Web.Api.Softijs.Commands.Comunes;
using Web.Api.Softijs.Commands.Ventas;
using Web.Api.Softijs.Comun;
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

        public async Task<List<Producto>> GetProductos()
        {
            return await context.Productos.AsNoTracking().ToListAsync();
        }

        public async Task<ResultadoBase> PostProducto(Producto p)
        {
            ResultadoBase resultado = new ResultadoBase();
            try
            {

                await context.AddAsync(p);
                await context.SaveChangesAsync(Constantes.DefaultSecurityValues.DefaultUserName); //TODO: replace this with the logged in user.
                resultado.Ok = true;
                resultado.CodigoEstado = 200;
                resultado.Message = "El producto se guardo exitosamente.";
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

        Task<ResultadoBase> IServicioProductos.PutProducto(Producto producto)
        {
            throw new NotImplementedException();
        }

        Task<ResultadoBase> IServicioProductos.DeleteProducto(int id)
        {
            throw new NotImplementedException();
        }
    }
}
