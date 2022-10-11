using System;
using System.Collections.Generic;
using Web.Api.Softijs.Models.Interfaces;

namespace Web.Api.Softijs.Models
{
    public partial class ComprobantesPago 
    {
        public ComprobantesPago()
        {
            DetallesOrdenesPagos = new HashSet<DetallesOrdenesPago>();
        }

        public int IdComprobantePago { get; set; }
        public int NroComprobante { get; set; }
        public string CreadoPor { get; set; } = null!;
        public string FechaCreacion { get; set; } = null!;
        public string ModificadoPor { get; set; } = null!;
        public string FechaModificacion { get; set; } = null!;
        public string? Descripcion { get; set; }

        public virtual ICollection<DetallesOrdenesPago> DetallesOrdenesPagos { get; set; }
    }
}
