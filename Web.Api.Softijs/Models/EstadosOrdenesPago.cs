using System;
using System.Collections.Generic;
using Web.Api.Softijs.Models.Interfaces;

namespace Web.Api.Softijs.Models
{
    public partial class EstadosOrdenesPago : IAuditable
    {
        public EstadosOrdenesPago()
        {
            OrdenesPagos = new HashSet<OrdenesPago>();
        }

        public int IdEstadoOrdenPago { get; set; }
        public string Descripcion { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public string ModificadoPor { get; set; } = null!;
        public DateTime FechaModificacion { get; set; }
        public string CreadoPor { get; set; } = null!;

        public virtual ICollection<OrdenesPago> OrdenesPagos { get; set; }
    }
}
