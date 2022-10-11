using System;
using System.Collections.Generic;
using Web.Api.Softijs.Models.Interfaces;

namespace Web.Api.Softijs.Models
{
    public partial class Gusto : IAuditable
    {
        public Gusto()
        {
            Productos = new HashSet<Producto>();
        }

        public int IdGusto { get; set; }
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public string CreadoPor { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public string ModificadoPor { get; set; } = null!;
        public DateTime FechaModificacion { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
