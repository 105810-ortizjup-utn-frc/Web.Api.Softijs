using Web.Api.Softijs.Commands.Ventas;
using Web.Api.Softijs.Models;

namespace Web.Api.Softijs.Commands
{
    public class ComandoCliente
    {
        public int? IdCliente { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string Dni { get; set; } = null!;
        public string? Calle { get; set; }
        public int? Numero { get; set; }
        public bool Activado { get; set; }
        public int? IdBarrio { get; set; }
        public int? IdCiudad { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public int? IdTipoFidelizacion { get; set; }

    }
}
