using Web.Api.Softijs.Models.Interfaces;

namespace Web.Api.Softijs.Models
{
    public partial class Usuario : IAuditable
    {
        public Usuario()
        {
            Liquidaciones = new HashSet<Liquidacione>();
            Pedidos = new HashSet<Pedido>();
            UsuariosRoles = new HashSet<UsuariosRole>();
        }

        public int IdUsuario { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Legajo { get; set; }
        public string Email { get; set; } = null!;
        public int? IdInformacionContacto { get; set; }
        public int? IdBarrio { get; set; }
        public int? IdCiudad { get; set; }
        public string? Calle { get; set; }
        public int? Numero { get; set; }
        public int IdTipoUsuario { get; set; }
        public bool Activo { get; set; }
        public string CreadoPor { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public string ModificadoPor { get; set; } = null!;
        public DateTime FechaModificacion { get; set; }
        public byte[] HashContrasenia { get; set; } = null!;

        public virtual Barrio? IdBarrioNavigation { get; set; }
        public virtual Ciudade? IdCiudadNavigation { get; set; }
        public virtual InformacionesContacto? IdInformacionContactoNavigation { get; set; }
        public virtual TiposUsuario IdTipoUsuarioNavigation { get; set; } = null!;
        public virtual ICollection<Liquidacione> Liquidaciones { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
        public virtual ICollection<UsuariosRole> UsuariosRoles { get; set; }
    }
}
