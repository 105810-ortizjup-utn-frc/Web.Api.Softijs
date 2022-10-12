using Web.Api.Softijs.Commands;
using Web.Api.Softijs.Models;
using Web.Api.Softijs.Results;

namespace Web.Api.Softijs.Services
{
    public interface IServicioProductos
    {
        List<Producto> GetProductos();
        Task<ResultadoBase> PostProducto(Producto producto);
    }
}
