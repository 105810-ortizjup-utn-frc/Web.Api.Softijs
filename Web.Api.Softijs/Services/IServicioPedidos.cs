using Web.Api.Softijs.Models;
using Web.Api.Softijs.Results;

namespace Web.Api.Softijs.Services
{
    public interface IServicioPedidos
    {
        Task<ResultadoBase> RegistrarPedido(Pedido pedido);
    }
}