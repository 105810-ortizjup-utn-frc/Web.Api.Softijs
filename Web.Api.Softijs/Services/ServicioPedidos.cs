using Microsoft.EntityFrameworkCore;
using Web.Api.Softijs.Comun;
using Web.Api.Softijs.DataContext;
using Web.Api.Softijs.Models;
using Web.Api.Softijs.Results;

namespace Web.Api.Softijs.Services
{
    public class ServicioPedidos : IServicioPedidos
    {
        private readonly SoftijsDevContext _softijsDevContext;

        public ServicioPedidos(SoftijsDevContext softijsDevContext)
        {
            _softijsDevContext = softijsDevContext;
        }

        public async Task<ResultadoBase> RegistrarPedido(Pedido pedido)
        {
            try
            {
                if (pedido == null)
                    throw new Exception("El pedido esta vacion.");

                if (!pedido.DetallesPedidos.Any())
                    throw new Exception("El pedido no tiene productos asociados.");

                if (pedido.IdCliente == 0)
                    throw new Exception("Porfavor seleciones el cliente.");

                if (!pedido.IdFormaPago.HasValue)
                    throw new Exception("Porfavor seleccione una forma de pago.");

                if (pedido.IdUsuario == 0)
                    throw new Exception("El vendedor no fue seleccionado.");

                if (pedido.DetallesPedidos.Any(x => x.Cantidad == 0))
                    throw new Exception("Todos los productos deben tener al menos una cantidad mayor o igual a 1.");

                if (pedido.DetallesPedidos.Any(x => x.Monto == 0))
                    throw new Exception("Al menos uno de los productos que quiere agregar tiene un costo de $0.00.");

                if (!pedido.DetallesPedidos.All(x => _softijsDevContext.Productos.AsNoTracking().Select(s => s.NroProducto).Contains(x.NroProducto)))
                    throw new Exception("Al menos uno de los productos que quiere agregar a su pedido no existe en nuestra base de datos.");

                await _softijsDevContext.AddAsync(pedido);
                await _softijsDevContext.SaveChangesAsync("ortizjup"); //TODO: replace this with the logged in user.
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new ResultadoBase { CodigoEstado = 500, Message = ex.Message, Ok = false });
            }

            return await Task.FromResult(new ResultadoBase { CodigoEstado = 200, Message = Constantes.DefaultMessages.DefaultSuccesMessage, Ok = true });
        }
    }
}
