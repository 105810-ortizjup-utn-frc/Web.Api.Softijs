using Web.Api.Softijs.Models;

namespace Web.Api.Softijs.Services
{
    public interface IServicioTipoFidelizacion
    {
        Task<List<TiposFidelizacione>> GetTipoFidelizacion();
    }
}
