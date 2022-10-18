using Web.Api.Softijs.Models;

namespace Web.Api.Softijs.Services
{
    public interface IServicioUnidadesMedidas
    {
        Task<List<UnidadesMedida>> GetUnidadesMedida();
    }
}
