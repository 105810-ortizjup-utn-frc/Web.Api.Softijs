using System;
using System.Collections.Generic;
using Web.Api.Softijs.Models.Interfaces;

namespace Web.Api.Softijs.Models
{
    public partial class Role : IAuditable
    {
        public Role()
        {
            UsuariosRoles = new HashSet<UsuariosRole>();
        }

        public int IdRol { get; set; }
        public string Codigo { get; set; } = null!;
        public string? Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string ModificadoPor { get; set; } = null!;
        public DateTime FechaModificacion { get; set; }
        public string CreadoPor { get; set; } = null!;

        public virtual ICollection<UsuariosRole> UsuariosRoles { get; set; }
    }
}
