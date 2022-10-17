using Web.Api.Softijs.Commands.Comunes;

namespace Web.Api.Softijs.Services.Comunes
{
    public interface IServicioUsuarios
    {
        Task<List<ComboBoxItemDto>> GetUsuariosForComboBox();
    }
}