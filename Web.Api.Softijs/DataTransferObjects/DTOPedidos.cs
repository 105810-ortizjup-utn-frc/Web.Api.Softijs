using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Api.Softijs.DataTransferObjects
{
    public class DTOPedidos
    {
        public int NroPedido { set; get; }
        public string? Cliente { set; get; }
        public string? Vendedor { set; get; }
        public DateTime Fecha { set; get; }
        public decimal Total { set; get; }

        public DTOPedidos(int nroPedido, string cliente, string vendedor, DateTime fecha, decimal total)
        {
            this.NroPedido = nroPedido;
            this.Cliente = cliente;
            this.Vendedor = vendedor;
            this.Fecha = fecha;
            this.Total = total;
        }
    }
}
