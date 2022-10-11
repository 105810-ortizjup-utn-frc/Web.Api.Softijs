using System;
using System.Collections.Generic;
using Web.Api.Softijs.Models.Interfaces;

namespace Web.Api.Softijs.Models
{
    public partial class InformacionesContacto : IAuditable
    {
        public InformacionesContacto()
        {
            Clientes = new HashSet<Cliente>();
            Proveedores = new HashSet<Proveedore>();
            Usuarios = new HashSet<Usuario>();
        }

        public int IdInformacionContacto { get; set; }
        public string? Telefono { get; set; }
        public byte[]? Email { get; set; }
        public string? Celular { get; set; }
        public string CreadoPor { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public string ModificadoPor { get; set; } = null!;
        public DateTime FechaModificacion { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Proveedore> Proveedores { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
