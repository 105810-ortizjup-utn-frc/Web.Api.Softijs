using Web.Api.Softijs.Commands;
using Web.Api.Softijs.Commands.Comunes;
using Web.Api.Softijs.DataTransferObjects;
using Web.Api.Softijs.Models;
using Web.Api.Softijs.Results;

namespace Web.Api.Softijs.Services.Comunes
{
    public interface IServicioClientes
    {
        Task<List<ComboBoxItemDto>> GetClientesForComboBox();
        Task<List<DTOCliente>> GetClientes();
        Task<List<InformacionesContacto>> GetInfoContacto();
        Task<ResultadoBase> PostCliente(ComandoCliente cliente);
        Task<Cliente> GetClienteByID(int id);
        Task<ResultadoBase> PutCliente(ComandoCliente cliente);
        Task<ResultadoBase> DeleteCliente(int id);
    }
}