using Web.Api.Softijs.Commands.Comunes;
using Web.Api.Softijs.DataTransferObjects;

namespace Web.Api.Softijs.Services.Comunes
{
    public interface IServicioUsuarios
    {
        Task<List<ComboBoxItemDto>> GetUsuariosForComboBox();
        Task<DTOUsuarioById> GetUsuariosById(int id);
    }
}