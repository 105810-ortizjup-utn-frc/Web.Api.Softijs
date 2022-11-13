using Microsoft.EntityFrameworkCore;
using Web.Api.Softijs.Commands.Comunes;
using Web.Api.Softijs.Comun;
using Web.Api.Softijs.DataContext;
using Web.Api.Softijs.DataTransferObjects;
using Web.Api.Softijs.Models;
using Web.Api.Softijs.Results;
using Web.Api.Softijs.Services.Security;

namespace Web.Api.Softijs.Services.Ventas
{
    public class ServicioPedidos : IServicioPedidos
    {
        private readonly SoftijsDevContext _softijsDevContext;
        private readonly ISecurityService _securityService;

        public ServicioPedidos(SoftijsDevContext softijsDevContext, ISecurityService securityService)
        {
            _softijsDevContext = softijsDevContext;
            _securityService = securityService;
        }

        public async Task<List<ComboBoxItemDto>> GetPedidosForComboBox()
        {
            return await _softijsDevContext.Pedidos.AsNoTracking().Select<Pedido, ComboBoxItemDto>(x => x).ToListAsync();
        }

        public async Task<ResultadoBase> RegistrarPedido(Pedido pedido)
        {
            try
            {
                ExecuteCustomValidations(pedido);
                await _softijsDevContext.AddAsync(pedido);
                await _softijsDevContext.SaveChangesAsync(_securityService.GetUserName() ?? Constantes.DefaultSecurityValues.DefaultUserName);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new ResultadoBase { CodigoEstado = 500, Message = ex.Message, Ok = false });
            }

            return await Task.FromResult(new ResultadoBase { CodigoEstado = 200, Message = Constantes.DefaultMessages.DefaultSuccesMessage.ToString(), Ok = true, Resultado = pedido.NroPedido });
        }

        public async Task<List<DTOPedidos>> GetPedidos()
        {
            var query = (from prd in _softijsDevContext.Pedidos.Where(c=>c.Fecha.Month.Equals(DateTime.Now.Month) && c.Fecha.Year.Equals(DateTime.Now.Year)).Include(x => x.DetallesPedidos).AsNoTracking()
                         join cl in _softijsDevContext.Clientes.AsNoTracking() on prd.IdCliente equals cl.IdCliente
                         join vd in _softijsDevContext.Usuarios.AsNoTracking() on prd.IdUsuario equals vd.IdUsuario
                         select new DTOPedidos
                         {
                             NroPedido = prd.NroPedido,
                             Cliente = $"{cl.Nombre} {cl.Apellido}",
                             Vendedor = $"{vd.Nombre} {vd.Apellido}",
                             Total = prd.DetallesPedidos.Sum(x => x.PrecioUnitario * x.Cantidad),
                             Fecha = prd.Fecha
                         });
            return await query.OrderByDescending(x=>x.Fecha).ToListAsync();
        }

        public async Task<List<DTODetallePedido>> GetDetallePedidos(int id)
        {
            var detalles = await _softijsDevContext.DetallesPedidos.Where(c => c.NroPedido.Equals(id)).ToListAsync();
            List<DTODetallePedido> listaDTO = new List<DTODetallePedido>();
            foreach (var item in detalles)
            {
                var producto = await _softijsDevContext.Productos.Where(c => c.NroProducto.Equals(item.NroProducto)).FirstOrDefaultAsync();
                DTODetallePedido detalle = new DTODetallePedido();
                detalle.nroDetalle = item.NroDetallePedido;
                detalle.Producto = producto.Nombre;
                detalle.Cantidad = item.Cantidad;
                detalle.Monto = item.PrecioUnitario;
                listaDTO.Add(detalle);
            }
            return listaDTO;
        }

        private void ExecuteCustomValidations(Pedido pedido)
        {
            if (pedido == null)
                throw new Exception("El pedido esta vacion.");

            if (!pedido.DetallesPedidos.Any())
                throw new Exception("El pedido no tiene productos asociados.");

            if (pedido.IdCliente == 0)
                throw new Exception("Porfavor seleciones el cliente.");

            if (pedido.IdUsuario == 0)
                throw new Exception("El vendedor no fue seleccionado.");

            if (pedido.DetallesPedidos.Any(x => x.Cantidad == 0))
                throw new Exception("Todos los productos deben tener al menos una cantidad mayor o igual a 1.");

            if (pedido.DetallesPedidos.Any(x => x.PrecioUnitario == 0))
                throw new Exception("El costo total del pedido no puede ser de $0.00.");

            if (!pedido.PedidosFormasPagos.Any())
                throw new Exception("Debe seleccionar al menos un medio de pago.");

            if (!pedido.DetallesPedidos.All(x => _softijsDevContext.Productos.AsNoTracking().Select(s => s.NroProducto).Contains(x.NroProducto)))
                throw new Exception("Al menos uno de los productos que quiere agregar a su pedido no existe en nuestra base de datos.");

            if (!_softijsDevContext.Usuarios.AsNoTracking().Any(x => x.IdUsuario == pedido.IdUsuario && x.Activo))
                throw new Exception("El vendedor que selecciono no existe en la base de datos.");

            if (!_softijsDevContext.Clientes.AsNoTracking().Any(x => x.IdCliente == pedido.IdCliente && x.Activado))
                throw new Exception("El cliente que selecciono no existe en la base de datos.");

            if (!_softijsDevContext.EstadosPedidos.AsNoTracking().Any(x => x.IdEstadoPedido == pedido.IdEstadoPedido))
                throw new Exception("El estado de pedido que selecciono no existe en la base de datos.");
        }
    }
}
