using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Api.Softijs.Results
{
    public class ResultadoBase
    {
        public string Error { set; get; }
        public bool Ok { set; get; }
        public int CodigoEstado { set; get; }
    }
}
