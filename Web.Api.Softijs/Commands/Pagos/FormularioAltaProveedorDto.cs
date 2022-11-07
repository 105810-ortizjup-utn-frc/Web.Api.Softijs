using Web.Api.Softijs.Models;

namespace Web.Api.Softijs.Commands.Pagos
{
    public class FormularioAltaProveedorDto
    {
        public int IdProveedor { get; set; }
        public string Nombre { get; set; } = null!;
        public int? IdBarrio { get; set; }
        public int? IdCiudad { get; set; }
        public string? Calle { get; set; }
        public int? Numero { get; set; }
        public InformacionesContactoDto? InformacionContactoDto { get; set; }

        public static implicit operator Proveedore(FormularioAltaProveedorDto dto)
        {
            return new Proveedore
            {
                IdProveedor = dto.IdProveedor,
                Nombre = dto.Nombre,
                IdInformacionContactoNavigation = dto.InformacionContactoDto,
                IdBarrio = dto.IdBarrio,
                IdCiudad = dto.IdCiudad,
                Calle = dto.Calle,
                Numero = dto.Numero
            };
        }
    }
}
