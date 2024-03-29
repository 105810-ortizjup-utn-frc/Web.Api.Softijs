using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Api.Softijs.Commands.Comunes;
using Web.Api.Softijs.Commands.Ventas;
using Web.Api.Softijs.Comun;
using Web.Api.Softijs.DataContext;
using Web.Api.Softijs.DataTransferObjects;
using Web.Api.Softijs.Models;
using Web.Api.Softijs.Results;
using Web.Api.Softijs.Services.Security;

namespace Web.Api.Softijs.Services
{
    public class ServicioProductos : IServicioProductos
    {
        private readonly SoftijsDevContext context;
        private readonly ISecurityService _securityService;

        public ServicioProductos(SoftijsDevContext _context, ISecurityService securityService)
        {
            this.context = _context;
            _securityService = securityService;
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
            return await context.Productos.Include(x => x.IdUnidadMedidaNavigation).AsNoTracking().Where(x => x.Activo).Select<Producto, ComboBoxItemDto>(x => x).ToListAsync();
        }

        public async Task<List<Producto>> GetProductos()
        {
            return await context.Productos.Include(x => x.IdGustoNavigation).Include(x=>x.IdUnidadMedidaNavigation).AsNoTracking().OrderByDescending(x => x.FechaModificacion).ToListAsync();
        }

        public async Task<ResultadoBase> PostProducto(Producto p)
        {
            ResultadoBase resultado = new ResultadoBase();
            try
            {
                var gusto = await context.Gustos.FirstOrDefaultAsync();
                p.IdGusto = gusto?.IdGusto;
                await context.AddAsync(p);
                await context.SaveChangesAsync(_securityService.GetUserName() ?? Constantes.DefaultSecurityValues.DefaultUserName);
                resultado.Ok = true;
                resultado.CodigoEstado = 200;
                resultado.Message = "El producto se guard� exitosamente.";
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

        public async Task<ResultadoBase> PutProducto(DTOProducto p)
        {
            ResultadoBase resultado = new ResultadoBase();
            var producto = await context.Productos.Where(c => c.Codigo.Equals(p.Codigo)).FirstOrDefaultAsync();
            if (producto != null)
            {
                producto.PuntoNecesario = p.PuntoNecesario;
                producto.PuntoOtorgado = p.PuntoOtorgado;
                producto.Precio = p.Precio;
                producto.Activo = p.Activo;
                context.Update(producto);
                await context.SaveChangesAsync(_securityService.GetUserName() ?? Constantes.DefaultSecurityValues.DefaultUserName);
                resultado.Ok = true;
                resultado.CodigoEstado = 200;
                resultado.Message = "El producto se modific� exitosamente.";
            }
            else
            {
                resultado.Ok = false;
                resultado.CodigoEstado = 400;
                resultado.Message = "Error al modificar un producto";
            }
            return resultado;
            
        }

        public async Task<ResultadoBase> DeleteProducto(int id)
        {
            ResultadoBase resultado = new ResultadoBase();
            var producto = await context.Productos.Where(c => c.NroProducto.Equals(id)).FirstOrDefaultAsync();
            if(producto != null)
            {
                resultado.Ok = true;
                resultado.CodigoEstado = 200;
                resultado.Message = "El producto se desactiv� exitosamente.";
                producto.Activo = false;
                context.Update(producto);
                await context.SaveChangesAsync(_securityService.GetUserName() ?? Constantes.DefaultSecurityValues.DefaultUserName);
            }
            else
            {
                resultado.Ok = false;
                resultado.CodigoEstado = 400;
                resultado.Message = "Error al borrar un producto";
                return resultado;
            }

            return resultado;
        }

        public async Task<DTOProducto> GetProductoById(int id)
        {
            try
            {
                Producto producto = await context.Productos.Where(c => c.NroProducto.Equals(id)).FirstOrDefaultAsync();
                DTOProducto dto = new DTOProducto();
                dto.nroProducto = producto.NroProducto;
                dto.Codigo = producto.Codigo;
                dto.nombre = producto.Nombre;
                dto.FechaVencimiento = producto.FechaVencimiento;
                dto.IdProveedor = producto.IdProveedor;
                dto.Precio = producto.Precio;
                dto.Lote = producto.Lote;
                dto.PuntoNecesario = producto.PuntoNecesario;
                dto.PuntoOtorgado = producto.PuntoOtorgado;
                dto.Activo = producto.Activo;
                dto.IdUnidadMedida = producto.IdUnidadMedida;
                dto.IdGusto = producto.IdGusto;
                dto.IdMarca = producto.IdMarca;
                dto.IdCategoria = producto.IdCategoria;

                return dto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        async public Task<ResultadoBase> ActivarProducto(int id)
        {
            ResultadoBase resultado = new ResultadoBase();
            var producto = await context.Productos.Where(c => c.NroProducto.Equals(id)).FirstOrDefaultAsync();
            if (producto != null)
            {
                resultado.Ok = true;
                resultado.CodigoEstado = 200;
                resultado.Message = "El producto se activ� exitosamente.";
                producto.Activo = true;
                context.Update(producto);
                await context.SaveChangesAsync(_securityService.GetUserName() ?? Constantes.DefaultSecurityValues.DefaultUserName);
            }
            else
            {
                resultado.Ok = false;
                resultado.CodigoEstado = 400;
                resultado.Message = "Error al borrar un producto";
                return resultado;
            }

            return resultado;
        }
    }
}
