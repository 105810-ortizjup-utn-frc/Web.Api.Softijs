using Web.Api.Softijs.Commands.Comunes;
using Web.Api.Softijs.Models;
using Web.Api.Softijs.Results;

namespace Web.Api.Softijs.Services.Ventas
{
    public interface IServicioPedidos
    {
        Task<List<ComboBoxItemDto>> GetPedidosForComboBox();
        Task<ResultadoBase> RegistrarPedido(Pedido pedido);
    }
}