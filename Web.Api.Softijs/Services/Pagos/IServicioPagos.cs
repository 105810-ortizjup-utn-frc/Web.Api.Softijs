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
        Task<List<DTODetalleOrdenPago>> GetDetallesOrdenesPago();
        Task<ResultadoBase> AutorizarFirma1(int idDetalleOrdenPago);
        Task<ResultadoBase> AutorizarFirma2(int idDetalleOrdenPago);
        Task<List<DTOLiquidaciones>> GetDetallesLiquidaciones();

        Task<DTOLiquidaciones> GetLiquidacionesById(int id);

    }
}
