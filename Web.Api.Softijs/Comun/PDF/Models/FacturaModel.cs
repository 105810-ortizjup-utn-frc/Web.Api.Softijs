using System.Reflection;
using Web.Api.Softijs.Models;

namespace Web.Api.Softijs.Comun.PDF.Models
{
    public class FacturaModel
    {
        #region Empresa
        public string ImagePath => Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), $"Comun/PDF/Assets/logo2.jpg");
        public string NumeroFactura { get; set; }
        public string FechaEmision { get; set; }
        public string CuitEmpresa => "20-35958556-3";
        public string Direccion => "Avenida Cruz Roja, 1430. Provincia: Córdoba. Ciudad: Córdoba.";
        #endregion

        #region Comprador
        public string DireccionComprador { get; set; }
        public string CuilComprador { get; set; }
        #endregion

        #region Venta
        public Pedido Pedido { get; set; }
        public List<PedidoFormaPagoProducto> PedidoFormaPagoProductos { get; set; }
        public decimal MontoTotalFactura { get; set; }
        public decimal MontoDelIva => ((MontoTotalFactura * 21) / 100);
        public string MetodoPago { get; set; }
        #endregion

        #region Vendedor
        public string Vendedor { get; set; }
        #endregion
        #region General
        public DateTime VtoCae => DateTime.Now.AddDays(10);
        #endregion
    }
}
