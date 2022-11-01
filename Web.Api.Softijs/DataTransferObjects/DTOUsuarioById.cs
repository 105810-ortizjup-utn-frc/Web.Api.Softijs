using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Api.Softijs.DataTransferObjects
{
    public class DTOUsuarioById
    {
       
        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public string? Legajo { get; set; }

        public string? Email { get; set; }

        public string? ContraseniaActual { get; set; }
        public string? ContraseniaNuevo { get; set; }
    }
}
