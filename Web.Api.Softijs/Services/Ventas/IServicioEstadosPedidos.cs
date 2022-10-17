using Web.Api.Softijs.Commands.Comunes;

namespace Web.Api.Softijs.Services.Ventas
{
    public interface IServicioEstadosPedidos
    {
        Task<List<ComboBoxItemDto>> GetEstadosPedidosForComboBox();
    }
}