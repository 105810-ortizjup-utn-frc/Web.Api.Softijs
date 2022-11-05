using Web.Api.Softijs.DataTransferObjects;
using Web.Api.Softijs.Models;
using Web.Api.Softijs.Results;

namespace Web.Api.Softijs.Services.Pagos
{
    public interface IServicioPagos
    {

        Task<List<DTOordenP>> GetOrdenP();

        Task<List<DTOPagosPendientes>> GetPagosPendientes();
        Task<List<DTOComprobanteDePago>> GetComprobantePago();
        Task<DTOComprobanteDePago> GetComprobanteById(int id);

        Task<ResultadoBase> PostComprobante(ComprobantesPago comprobantes);

    }
}
