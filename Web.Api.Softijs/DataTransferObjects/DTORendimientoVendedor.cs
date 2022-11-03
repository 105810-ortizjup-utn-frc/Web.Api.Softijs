using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Api.Softijs.DataTransferObjects
{
    public class DTORendimientoVendedor
    {
        public string nombre { set; get; }
        public int cantidadVentas { set; get; }
        public DateTime fecha { set; get; }
    }
}
