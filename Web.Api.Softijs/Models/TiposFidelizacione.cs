using System;
using System.Collections.Generic;
using Web.Api.Softijs.Models.Interfaces;

namespace Web.Api.Softijs.Models
{
    public partial class TiposFidelizacione 
    { 
        public TiposFidelizacione()
        {
            Clientes = new HashSet<Cliente>();
        }

        public int IdTipoFidelizacion { get; set; }
        public string Codigo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string Descuento { get; set; } = null!;
        public string CreadoPor { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public string ModificadoPor { get; set; } = null!;
        public string FechaModificacion { get; set; } = null!;

        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
