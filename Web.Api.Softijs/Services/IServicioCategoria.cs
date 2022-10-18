using Web.Api.Softijs.Models;

namespace Web.Api.Softijs.Services
{
    public interface IServicioCategoria
    {
        Task<List<Categoria>> GetCategorias();
    }
}
