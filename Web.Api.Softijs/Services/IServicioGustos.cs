using Web.Api.Softijs.Models;

namespace Web.Api.Softijs.Services
{
    public interface IServicioGustos
    {
        Task<List<Gusto>> GetGustos();
    }
}
