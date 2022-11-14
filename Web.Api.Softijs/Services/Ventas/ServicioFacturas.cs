using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.EntityFrameworkCore;
using RazorLight;
using System.Globalization;
using System.Reflection;
using System.Text;
using Web.Api.Softijs.Comun.PDF;
using Web.Api.Softijs.Comun.PDF.Models;
using Web.Api.Softijs.DataContext;

namespace Web.Api.Softijs.Services.Ventas
{
    public class ServicioFacturas : IServicioFacturas
    {
        private readonly SoftijsDevContext _context;
        private readonly IRazorLightEngine _razorEngine;
        private readonly IConverter _pdfConverter;

        public ServicioFacturas(SoftijsDevContext context,
            IRazorLightEngine razorLightEngine,
            IConverter pdfConverter)
        {
            _context = context;
            _razorEngine = razorLightEngine;
            _pdfConverter = pdfConverter;
        }

        public async Task<byte[]> CrearFactura(int nroPedido)
        {
            try
            {
                var model = await this.GetFacturaModel(nroPedido);
                var templatePath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), $"Comun/PDF/Templates/Factura.cshtml");
                string template = await _razorEngine.CompileRenderAsync(templatePath, model);
                var globalSettings = new GlobalSettings
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                    Margins = new MarginSettings() { Top = 10, Bottom = 10, Left = 10, Right = 10 },
                    DocumentTitle = $"Factura_Softijs_{nroPedido:00000000}",
                };
                var objectSettings = new ObjectSettings
                {
                    PagesCount = true,
                    HtmlContent = template,
                    WebSettings = { DefaultEncoding = "utf-8" },
                    FooterSettings = { FontName = "Arial", FontSize = 12, Line = true, Right = "Pagina [page] de [toPage]" }
                };
                var pdf = new HtmlToPdfDocument()
                {
                    GlobalSettings = globalSettings,
                    Objects = { objectSettings }
                };
                byte[] file = _pdfConverter.Convert(pdf);
                return file;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async Task<FacturaModel?> GetFacturaModel(int nroPedido)
        {
                return await _context.Pedidos
                   .Include(x => x.DetallesPedidos)
                       .ThenInclude(x => x.NroProductoNavigation)
                   .Include(x => x.PedidosFormasPagos)
                       .ThenInclude(x => x.IdFormaPagoNavigation)
                   .Include(x => x.IdClienteNavigation)
                       .ThenInclude(x => x.IdCiudadNavigation)
                   .Include(x => x.IdClienteNavigation)
                       .ThenInclude(x => x.IdCiudadNavigation)
                   .Include(x => x.IdClienteNavigation)
                       .ThenInclude(x => x.IdBarrioNavigation)
                   .Include(x => x.IdUsuarioNavigation)
                   .Where(x => x.NroPedido == nroPedido)
                   .Select(p => new FacturaModel
                   {
                       Vendedor = $"{p.IdUsuarioNavigation.Apellido}, {p.IdUsuarioNavigation.Nombre}",
                       FechaEmision = $"{p.FechaCreacion:MM/dd/yyyy HH:mm:ss}",
                       NumeroFactura = $"{p.NroPedido:000000000}",
                       CuilComprador = $"{p.IdClienteNavigation.Dni}",
                       DireccionComprador = $"{p.IdClienteNavigation.Calle}, {p.IdClienteNavigation.Numero}. Barrio: {p.IdClienteNavigation.IdBarrioNavigation.Descripcion} - Ciudad: {p.IdClienteNavigation.IdCiudadNavigation.Descripcion} - Estado: {p.IdClienteNavigation.IdBarrioNavigation.Descripcion}",
                       Pedido = p,
                       MontoTotalFactura = p.DetallesPedidos.Sum(x => x.Cantidad * x.PrecioUnitario),
                       MetodoPago = string.Join(" - ", p.PedidosFormasPagos.Select(s => s.IdFormaPagoNavigation.Descripcion).ToList()),
                       PedidoFormaPagoProductos = p.DetallesPedidos.Select(x => new PedidoFormaPagoProducto
                       {
                           Cantidad = x.Cantidad,
                           NombreProducto = x.NroProductoNavigation.Nombre,
                           PrecioUnitario = x.PrecioUnitario,
                       }).ToList()
                   })
                   .FirstOrDefaultAsync();
        }
    }
}
