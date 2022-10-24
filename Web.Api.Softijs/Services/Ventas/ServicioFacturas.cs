using Microsoft.EntityFrameworkCore;
using System.Text;
using Web.Api.Softijs.Comun.PDF;
using Web.Api.Softijs.DataContext;

namespace Web.Api.Softijs.Services.Ventas
{
    public class ServicioFacturas : IServicioFacturas
    {
        private readonly SoftijsDevContext _context;

        public ServicioFacturas(SoftijsDevContext context)
        {
            _context = context;
        }

        public byte[] CreateFactura(int nroPedido)
        {
            return new byte[3];
        }
    }
}
