using Web.Api.Softijs.Models.Interfaces;

namespace Web.Api.Softijs.Models
{
    public partial class EstadosPedido : IAuditable
    {
        public EstadosPedido()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int IdEstadoPedido { get; set; }
        public string Codigo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string CreadoPor { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public string ModificadoPor { get; set; } = null!;
        public DateTime FechaModificacion { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
