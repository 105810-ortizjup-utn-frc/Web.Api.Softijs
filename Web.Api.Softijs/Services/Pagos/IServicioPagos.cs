using Web.Api.Softijs.DataTransferObjects;
using Web.Api.Softijs.Models;
using Web.Api.Softijs.Results;

namespace Web.Api.Softijs.Services.Pagos
{
    public interface IServicioPagos
    {
        Task<List<DTOordenP>> GetOrdenP();
        Task<List<DTOPagosPendientes>> GetPagosPendientes();
        Task<DTOestadoOP> GetOrdenPagoById(int id);
        Task<ResultadoBase> PutOrden(DTOestadoOP ordenesPagos); 
    }
}
