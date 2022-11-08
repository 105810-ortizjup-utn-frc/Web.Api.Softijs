using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Api.Softijs.DataTransferObjects
{
    public class DTOCliente
    {
        public int? idCliente { set; get; }
        public string? nombre { set; get; }
        public string? apellido  { set; get; }
        public string? dni { set; get; }
        public string? email { set; get; }
        public string? celular { set; get; }
        public string? calle { set; get; }
        public int? numero { set; get; }
    }
}
