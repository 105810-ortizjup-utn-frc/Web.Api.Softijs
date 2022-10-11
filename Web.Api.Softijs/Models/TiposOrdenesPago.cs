using System;
using System.Collections.Generic;
using Web.Api.Softijs.Models.Interfaces;

namespace Web.Api.Softijs.Models
{
    public partial class TiposOrdenesPago : IAuditable
    {
        public TiposOrdenesPago() 
        {
            OrdenesPagos = new HashSet<OrdenesPago>();
        }

        public int IdTipoOrdenPago { get; set; }
        public string Codigo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public string ModificadoPor { get; set; } = null!;
        public DateTime FechaModificacion { get; set; }
        public string CreadoPor { get; set; } = null!;

        public virtual ICollection<OrdenesPago> OrdenesPagos { get; set; }
    }
}
