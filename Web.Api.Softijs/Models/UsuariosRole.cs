using System;
using System.Collections.Generic;
using Web.Api.Softijs.Models.Interfaces;

namespace Web.Api.Softijs.Models
{
    public partial class UsuariosRole : IAuditable
    {
        public int IdUsuarioRol { get; set; }
        public int? IdRol { get; set; }
        public int? IdUsuario { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string ModificadoPor { get; set; } = null!;
        public DateTime FechaModificacion { get; set; }
        public string CreadoPor { get; set; } = null!;

        public virtual Role? IdRolNavigation { get; set; }
        public virtual Usuario? IdUsuarioNavigation { get; set; }
    }
}
