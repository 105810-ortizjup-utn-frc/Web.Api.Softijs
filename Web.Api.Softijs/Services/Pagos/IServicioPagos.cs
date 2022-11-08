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
        Task<List<DTODetalleOrdenPago>> GetDetallesOrdenesPago(int id);
        Task<ResultadoBase> AutorizarFirma1(int idDetalleOrdenPago);
        Task<ResultadoBase> AutorizarFirma2(int idDetalleOrdenPago);
        Task<List<DTOLiquidaciones>> GetDetallesLiquidaciones();

        Task<DTOLiquidaciones> GetLiquidacionesById(int id);
        Task<DTOComprobanteDePago> GetComprobanteById(int id);


        Task<DTOestadoOP> GetOrdenPagoById(int id);
        Task<ResultadoBase> PutOrden(DTOestadoOP ordenesPagos); 

        Task<List<ComboBoxItemDto>> GetProveedoresForComboBox();

        Task<List<ComboBoxItemDto>> GetLiquidacionForComboBox();

        Task<List<LIquidacionFullDto>> GetLiquidacionForList();

        Task<List<ComboBoxItemDto>> GetFormasDePagosForComboBoxItem();

        Task<ResultadoBase> SaveOrdenPago(OrdenesPago entity);

        Task<AltaOrdenPagoDto> GetAltaOrdenPagoDtoById(int id);

        Task SaveProveedor(Proveedore proveedor);
    }
}
