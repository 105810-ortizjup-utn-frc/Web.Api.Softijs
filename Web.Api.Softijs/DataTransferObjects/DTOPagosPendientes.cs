using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Api.Softijs.DataTransferObjects
{
    public class DTOPagosPendientes
    {
        public int NroOrdenPago { set; get; }
        public DateTime FechaVencimiento { set; get; }
        public decimal Monto { set; get; }
        public string? CreadoPor { set; get; }
        public DateTime FechaCreacion { set; get; }
        public string? ModificadoPor { set; get; }
        public DateTime FechaModificacion { set; get; }
    }
}
