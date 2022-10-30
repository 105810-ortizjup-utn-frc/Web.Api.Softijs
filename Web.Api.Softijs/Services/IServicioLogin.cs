using Microsoft.AspNetCore.Mvc;
using Web.Api.Softijs.Commands;
using Web.Api.Softijs.Models;
using Web.Api.Softijs.Results;


namespace Web.Api.Softijs.Services
{
    public interface IServicioLogin
    {
        Task<List<Usuario>> GetUsuarios();
        Task<ComandoLogin> Login([FromBody] ComandoLogin comando);
    }
}