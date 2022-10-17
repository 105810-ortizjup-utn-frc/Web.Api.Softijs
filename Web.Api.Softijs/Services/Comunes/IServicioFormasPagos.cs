using Web.Api.Softijs.Commands.Comunes;

namespace Web.Api.Softijs.Services.Comunes
{
    public interface IServicioFormasPagos
    {
        Task<List<ComboBoxItemDto>> GetFormasPagosForComboBox();
    }
}