using Microsoft.EntityFrameworkCore;
using Web.Api.Softijs.Commands;
using Web.Api.Softijs.Commands.Comunes;
using Web.Api.Softijs.Comun;
using Web.Api.Softijs.DataContext;
using Web.Api.Softijs.DataTransferObjects;
using Web.Api.Softijs.Models;
using Web.Api.Softijs.Results;
using Web.Api.Softijs.Services.Security;

namespace Web.Api.Softijs.Services.Comunes
{
    public class ServicioClientes : IServicioClientes
    {
        private readonly SoftijsDevContext _context;
        private readonly ISecurityService _securityService;

        public ServicioClientes(SoftijsDevContext context, ISecurityService securityService)
        {
            _context = context;
            _securityService = securityService;
        }

        public async Task<List<ComboBoxItemDto>> GetClientesForComboBox()
        {
            return await _context.Clientes.AsNoTracking().Where(x => x.Activado).Select<Cliente, ComboBoxItemDto>(x => x).ToListAsync();
        }

        public async Task<List<DTOCliente>> GetClientes()
        {
            var query = (from cl in _context.Clientes.Where(c=>c.Activado.Equals(true)).AsNoTracking()
                         join ic in _context.InformacionesContactos.AsNoTracking() on cl.IdInformacionContacto equals ic.IdInformacionContacto
                         orderby cl.FechaModificacion descending
                         select new DTOCliente
                         {
                             idCliente = cl.IdCliente,
                             nombre = cl.Nombre,
                             apellido = cl.Apellido,
                             calle = cl.Calle,
                             celular = ic.Celular,
                             numero = cl.Numero,
                             email = ic.Email,
                             dni = cl.Dni  
                         }
                         );
            //var query = (from prd in _softijsDevContext.Pedidos.Include(x => x.DetallesPedidos).AsNoTracking()
            //             join cl in _softijsDevContext.Clientes.AsNoTracking() on prd.IdCliente equals cl.IdCliente
            //             join vd in _softijsDevContext.Usuarios.AsNoTracking() on prd.IdUsuario equals vd.IdUsuario
            //             select new DTOPedidos
            //             {
            //                 NroPedido = prd.NroPedido,
            //                 Cliente = $"{cl.Nombre} {cl.Apellido}",
            //                 Vendedor = $"{vd.Nombre} {vd.Apellido}",
            //                 Total = prd.DetallesPedidos.Sum(x => x.PrecioUnitario * x.Cantidad),
            //                 Fecha = prd.Fecha
            //             });
            return await query.ToListAsync();
        }

        public async Task<List<InformacionesContacto>> GetInfoContacto()
        {
            return await _context.InformacionesContactos.AsNoTracking().ToListAsync();
        }

        public async Task<ResultadoBase> PostCliente(ComandoCliente comando)
        {
            try
            {
                var cliente = new Cliente
                {
                    Nombre = comando.Nombre,
                    Apellido = comando.Apellido,
                    Dni = comando.Dni,
                    IdInformacionContactoNavigation = new InformacionesContacto
                    {
                        Telefono = comando.Telefono,
                        Email = comando.Email,
                        Celular = comando.Celular
                    },
                    IdCiudad = comando.IdCiudad,
                    IdBarrio = comando.IdBarrio,
                    Calle = comando.Calle,
                    Numero = comando.Numero,
                    IdTipoFidelizacion = comando.IdTipoFidelizacion,
                    Activado = true
                };
                await _context.AddAsync(cliente);
                await _context.SaveChangesAsync(_securityService.GetUserName() ?? Constantes.DefaultSecurityValues.DefaultUserName); //TODO: replace this with the logged in user.
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new ResultadoBase { CodigoEstado = 500, Message = ex.Message, Ok = false });
            }

            return await Task.FromResult(new ResultadoBase { CodigoEstado = 200, Message = Constantes.DefaultMessages.DefaultSuccesMessage.ToString(), Ok = true });
        }

        public async Task<ComandoCliente> GetClienteByID(int id)
        {
            var cliente =  await _context.Clientes
                .AsNoTracking()
                .Include(x => x.IdBarrioNavigation)
                .Include(x => x.IdCiudadNavigation)
                .Include(x => x.IdInformacionContactoNavigation)
                .Include(x => x.IdTipoFidelizacionNavigation)
                .FirstOrDefaultAsync(x => x.IdCliente == id);
            ComandoCliente comando = new ComandoCliente();

            if (cliente != null)
            {
                comando.IdCliente = cliente.IdCliente;
                comando.Nombre = cliente.Nombre;
                comando.Apellido = cliente.Apellido;
                comando.Dni = cliente.Dni;
                comando.Calle = cliente.Calle;
                comando.Numero = cliente.Numero;
                comando.Activado = cliente.Activado;
                comando.IdBarrio = cliente.IdBarrio;
                comando.IdCiudad = cliente.IdCiudad;
                comando.Telefono = cliente.IdInformacionContactoNavigation.Telefono;
                comando.Email = cliente.IdInformacionContactoNavigation.Email;
                comando.Celular = cliente.IdInformacionContactoNavigation.Celular;
                comando.IdTipoFidelizacion = cliente.IdTipoFidelizacion;
            }
            return comando;


        }

        public async Task<ResultadoBase> PutCliente(ComandoCliente comando)
        {
            try
            {
                var cliente = await _context.Clientes.Where(c => c.IdCliente.Equals(comando.IdCliente)).FirstOrDefaultAsync();
                cliente.Nombre = comando.Nombre;
                cliente.Apellido = comando.Apellido;
                cliente.Dni = comando.Dni;
                cliente.IdInformacionContactoNavigation = new InformacionesContacto
                {
                    Telefono = comando.Telefono,
                    Email = comando.Email,
                    Celular = comando.Celular
                };
                cliente.IdCiudad = comando.IdCiudad;
                cliente.IdBarrio = comando.IdBarrio;
                cliente.Calle = comando.Calle;
                cliente.Numero = comando.Numero;
                cliente.IdTipoFidelizacion = comando.IdTipoFidelizacion;
                cliente.Activado = true;
                _context.Update(cliente);
                await _context.SaveChangesAsync(_securityService.GetUserName() ?? Constantes.DefaultSecurityValues.DefaultUserName); //TODO: replace this with the logged in user.
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new ResultadoBase { CodigoEstado = 500, Message = ex.Message, Ok = false });
            }

            return await Task.FromResult(new ResultadoBase { CodigoEstado = 200, Message = Constantes.DefaultMessages.DefaultSuccesMessage.ToString(), Ok = true });
        }

        public async Task<ResultadoBase> DeleteCliente(int id)
        {
            ResultadoBase resultado = new ResultadoBase();
            var cliente = await _context.Clientes.Where(c => c.IdCliente.Equals(id)).FirstOrDefaultAsync();
            if (cliente != null)
            {
                resultado.Ok = true;
                resultado.CodigoEstado = 200;
                resultado.Message = "El cliente se desactivo exitosamente.";
                cliente.Activado = false;
                _context.Update(cliente);
                await _context.SaveChangesAsync(_securityService.GetUserName() ?? Constantes.DefaultSecurityValues.DefaultUserName);
            }
            else
            {
                resultado.Ok = false;
                resultado.CodigoEstado = 400;
                resultado.Message = "Error al desactivar el cliente";
                return resultado;
            }

            return resultado;
        }
    }
}
