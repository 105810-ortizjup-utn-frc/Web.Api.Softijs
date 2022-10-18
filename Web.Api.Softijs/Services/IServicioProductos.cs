using Web.Api.Softijs.Commands.Comunes;
using Web.Api.Softijs.Commands.Ventas;
using Web.Api.Softijs.Models;
using Web.Api.Softijs.Results;

namespace Web.Api.Softijs.Services
{
    public interface IServicioProductos
    {
        Task<InformacionProductoDto> GetInformacionProductoDtoById(int id);
        Task<List<ComboBoxItemDto>> GetProductosForComboBox();
        Task<List<Producto>> GetProductos();
        Task<ResultadoBase> PostProducto(Producto producto);
    }
}
