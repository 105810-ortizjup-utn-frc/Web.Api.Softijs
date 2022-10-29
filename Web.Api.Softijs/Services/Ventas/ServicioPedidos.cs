using Microsoft.EntityFrameworkCore;
using Web.Api.Softijs.Commands.Comunes;
using Web.Api.Softijs.Comun;
using Web.Api.Softijs.DataContext;
using Web.Api.Softijs.DataTransferObjects;
using Web.Api.Softijs.Models;
using Web.Api.Softijs.Results;

namespace Web.Api.Softijs.Services.Ventas
{
    public class ServicioPedidos : IServicioPedidos
    {
        private readonly SoftijsDevContext _softijsDevContext;

        public ServicioPedidos(SoftijsDevContext softijsDevContext)
        {
            _softijsDevContext = softijsDevContext;
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
                await _softijsDevContext.SaveChangesAsync(Constantes.DefaultSecurityValues.DefaultUserName); //TODO: replace this with the logged in user.
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new ResultadoBase { CodigoEstado = 500, Message = ex.Message, Ok = false });
            }

            return await Task.FromResult(new ResultadoBase { CodigoEstado = 200, Message = Constantes.DefaultMessages.DefaultSuccesMessage.ToString(), Ok = true });
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

            if (pedido.DetallesPedidos.Any(x => x.Monto == 0))
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

        async Task<List<DTOPedidos>> IServicioPedidos.GetPedidos()
        {
             List<Pedido> lista = await _softijsDevContext.Pedidos.AsNoTracking().ToListAsync();
            List<DTOPedidos> listaDTO = new List<DTOPedidos>();
            foreach (var item in lista)
            {
                var cliente = await _softijsDevContext.Clientes.Where(c => c.IdCliente.Equals(item.IdCliente)).FirstOrDefaultAsync();
                var vendedor = await _softijsDevContext.Usuarios.Where(c => c.IdUsuario.Equals(item.IdUsuario)).FirstOrDefaultAsync();
                var fecha = item.Fecha;
                var nroPedido = item.NroPedido;
                var detalles = await _softijsDevContext.DetallesPedidos.Where(c => c.NroPedido.Equals(item.NroPedido)).ToListAsync();
                decimal total = 0;
                foreach (var itemD in detalles)
                {
                    total += itemD.Monto * itemD.Cantidad;
                }
                DTOPedidos pedido = new DTOPedidos(nroPedido, cliente.Nombre, vendedor.Nombre, fecha,total);
                listaDTO.Add(pedido);        
            }
            return listaDTO;
            
        }

        async Task<List<DetallesPedido>> IServicioPedidos.GetDetallePedidos(int id)
        {
            return await _softijsDevContext.DetallesPedidos.Where(c=>c.NroPedido.Equals(id)).ToListAsync();
        }


    }
}
