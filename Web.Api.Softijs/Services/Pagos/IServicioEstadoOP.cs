using Web.Api.Softijs.Models;

namespace Web.Api.Softijs.Services.Pagos
{
    public interface IServicioEstadoOP
    {
        Task<List<EstadosOrdenesPago>> GetEstado();

    }
}
