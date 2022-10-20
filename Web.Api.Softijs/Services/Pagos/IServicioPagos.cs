using Web.Api.Softijs.Models;

namespace Web.Api.Softijs.Services.Pagos
{
    public interface IServicioPagos
    {

        Task<List<OrdenesPago>> GetOrdenP();

    }
}
