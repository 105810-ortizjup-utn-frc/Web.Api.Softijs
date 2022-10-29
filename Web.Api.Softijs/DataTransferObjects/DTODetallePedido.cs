using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Api.Softijs.DataTransferObjects
{
    public class DTODetallePedido
    {
        public int nroDetalle { set; get; }
        public string Producto { set; get; }
        public decimal Monto { set; get; }
        public int Cantidad { set; get; }
    }
}
