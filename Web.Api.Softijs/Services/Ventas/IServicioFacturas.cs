namespace Web.Api.Softijs.Services.Ventas
{
    public interface IServicioFacturas
    {
        Task<byte[]> CrearFactura(int nroPedido);
    }
}
