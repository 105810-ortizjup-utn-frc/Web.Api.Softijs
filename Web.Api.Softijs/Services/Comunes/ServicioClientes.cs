using Microsoft.EntityFrameworkCore;
using Web.Api.Softijs.Commands;
using Web.Api.Softijs.Commands.Comunes;
using Web.Api.Softijs.Comun;
using Web.Api.Softijs.DataContext;
using Web.Api.Softijs.Models;
using Web.Api.Softijs.Results;

namespace Web.Api.Softijs.Services.Comunes
{
    public class ServicioClientes : IServicioClientes
    {
        private readonly SoftijsDevContext _context;

        public ServicioClientes(SoftijsDevContext context)
        {
            _context = context;
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
                await _context.SaveChangesAsync(Constantes.DefaultSecurityValues.DefaultUserName); //TODO: replace this with the logged in user.
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new ResultadoBase { CodigoEstado = 500, Message = ex.Message, Ok = false });
            }

            return await Task.FromResult(new ResultadoBase { CodigoEstado = 200, Message = Constantes.DefaultMessages.DefaultSuccesMessage.ToString(), Ok = true });
        }
    }
}
