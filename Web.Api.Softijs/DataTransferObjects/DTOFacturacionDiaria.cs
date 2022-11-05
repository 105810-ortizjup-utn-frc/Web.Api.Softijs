using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Api.Softijs.DataTransferObjects
{
    public class DTOFacturacionDiaria
    {
        public decimal montoVendido { set; get; }
        public string dia { set; get; }
    }
}
