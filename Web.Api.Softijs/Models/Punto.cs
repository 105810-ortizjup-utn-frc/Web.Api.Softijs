using System;
using System.Collections.Generic;
using Web.Api.Softijs.Models.Interfaces;

namespace Web.Api.Softijs.Models
{
    public partial class Punto : IAuditable
    {
        public int IdPunto { get; set; }
        public int IdCliente { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string ModificadoPor { get; set; } = null!;
        public DateTime FechaModificacion { get; set; }
        public int NroProducto { get; set; }
        public string CreadoPor { get; set; } = null!;

        public virtual Cliente IdClienteNavigation { get; set; } = null!;
        public virtual Producto NroProductoNavigation { get; set; } = null!;
    }
}
