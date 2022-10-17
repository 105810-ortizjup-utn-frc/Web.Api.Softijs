using Web.Api.Softijs.Commands.Comunes;

namespace Web.Api.Softijs.Services.Comunes
{
    public interface IServicioClientes
    {
        Task<List<ComboBoxItemDto>> GetClientesForComboBox();
    }
}