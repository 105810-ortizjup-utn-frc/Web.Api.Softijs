using System;
using Web.Api.Softijs.Models;

namespace Web.Api.Softijs.Comun.PDF
{
    public class FacturaModel
    {
        #region Empresa
        public string Cuit => "20-35958556-3";
        public string FechaEmision => $"{DateTime.Now:MM/dd/yyyy}";
        public string Direccion => "Avenida Cruz Roja, 1430. Provincia: Córdoba. Ciudad: Córdoba.";
        public int NumeroFactura { get; set; }
        #endregion

        #region Comprador
        public string DireccionComprador { get; set; }
        public string CUIL { get; set; }
        #endregion

        #region Venta
        public Pedido pedido { get; set; }
        public List<PedidoFormaPagoProducto> pedidoFormaPagoProductos { get; set; }
        public decimal MontoIva => (pedidoFormaPagoProductos.Sum(x => x.Cantidad * x.Monto) * (21 / 100));
        public decimal MontoSinIva => pedidoFormaPagoProductos.Sum(x => x.Cantidad * x.Monto);
        public decimal MontoTotalConIva => MontoIva + MontoSinIva;
        #endregion

        #region General
        public DateTime VtoCae => DateTime.Now.AddDays(10);
        #endregion
    }
}
