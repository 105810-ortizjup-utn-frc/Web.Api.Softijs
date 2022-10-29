using Web.Api.Softijs.Commands.Comunes;
using Web.Api.Softijs.Models;

namespace Web.Api.Softijs.Services.Comunes
{
    public interface IServicioBarrios
    {
        Task<List<Barrio>> GetBarrios();
        Task<List<Ciudade>> GetCiudades();
        Task<List<Provincia>> GetProvincias();

    }
}
