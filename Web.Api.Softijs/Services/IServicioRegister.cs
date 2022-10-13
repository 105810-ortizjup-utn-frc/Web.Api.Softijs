using System.Text;
using Web.Api.Softijs.Models;
using Web.Api.Softijs.Results;


namespace Web.Api.Softijs.Services
{
    public interface IServicioRegister
    {
        Task<ResultadoBase> PostRegister(Usuario usuario);




      
    }
}
