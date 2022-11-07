using Web.Api.Softijs.Models;

namespace Web.Api.Softijs.Commands.Pagos
{
    public class InformacionesContactoDto
    {
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public string? Celular { get; set; }

        public static implicit operator InformacionesContacto(InformacionesContactoDto dto)
        {
            return new InformacionesContacto
            {
                Telefono = dto.Telefono,
                Celular = dto.Celular,
                Email = dto.Email
            };
        }
    }
}
