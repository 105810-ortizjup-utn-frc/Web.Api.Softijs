using Web.Api.Softijs.Models.Interfaces;

namespace Web.Api.Softijs.Models
{
    public partial class Cliente : IAuditable
    {
        public Cliente()
        {
            Pedidos = new HashSet<Pedido>();
            Puntos = new HashSet<Punto>();
        }

        public int IdCliente { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string Dni { get; set; } = null!;
        public int? IdInformacionContacto { get; set; }
        public int? IdBarrio { get; set; }
        public int? IdCiudad { get; set; }
        public string? Calle { get; set; }
        public int? Numero { get; set; }
        public int? IdTipoFidelizacion { get; set; }
        public bool Activado { get; set; }
        public string CreadoPor { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public string ModificadoPor { get; set; } = null!;
        public DateTime FechaModificacion { get; set; }

        public virtual Barrio? IdBarrioNavigation { get; set; }
        public virtual Ciudade? IdCiudadNavigation { get; set; }
        public virtual InformacionesContacto? IdInformacionContactoNavigation { get; set; }
        public virtual TiposFidelizacione? IdTipoFidelizacionNavigation { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
        public virtual ICollection<Punto> Puntos { get; set; }
    }
}
