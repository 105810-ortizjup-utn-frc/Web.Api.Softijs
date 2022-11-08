using Web.Api.Softijs.Commands.Comunes;

namespace Web.Api.Softijs.Services.Comunes
{
    public interface ILocationService
    {
        Task<List<ComboBoxItemDto>> GetBarriosForComboBox();
        Task<List<ComboBoxItemDto>> GetProvinciasForComboBox();
        Task<List<ComboBoxItemDto>> GetCiudadesForComboBox();
    }
}