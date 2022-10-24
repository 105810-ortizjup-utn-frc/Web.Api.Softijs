using Web.Api.Softijs.Results;

namespace Web.Api.Softijs.Commands.Ventas
{
    public class ResultadoFactura : ResultadoBase
    {
        public int NroPedido { get; set; }
        public byte[] File { get; set; }
    }
}
