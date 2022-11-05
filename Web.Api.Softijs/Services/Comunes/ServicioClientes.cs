using Microsoft.EntityFrameworkCore;
using Web.Api.Softijs.Commands;
using Web.Api.Softijs.Commands.Comunes;
using Web.Api.Softijs.Comun;
using Web.Api.Softijs.DataContext;
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

        public async Task<List<Cliente>> GetClientes()
        {
            return await _context.Clientes.AsNoTracking().ToListAsync();
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

        public async Task<Cliente> GetClienteByID(int id)
        {
            return await _context.Clientes
                .AsNoTracking()
                .Include(x => x.IdBarrioNavigation)
                .Include(x => x.IdCiudadNavigation)
                .Include(x => x.IdInformacionContactoNavigation)
                .Include(x => x.IdTipoFidelizacionNavigation)
                .FirstOrDefaultAsync(x => x.IdCliente == id);
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
                await _context.SaveChangesAsync();
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
