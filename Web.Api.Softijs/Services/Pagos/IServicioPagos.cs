using Web.Api.Softijs.Commands.Comunes;
using Web.Api.Softijs.Commands.Pagos;
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

        Task<List<ComboBoxItemDto>> GetProveedoresForComboBox();

        Task<List<ComboBoxItemDto>> GetLiquidacionForComboBox();

        Task<ResultadoBase> SaveOrdenPago(OrdenesPago entity);

        Task<AltaOrdenPagoDto> GetAltaOrdenPagoDtoById(int id);
    }
}
