using Microsoft.AspNetCore.Mvc;
using Web.Api.Softijs.Commands;
using Web.Api.Softijs.Models;
using Web.Api.Softijs.Results;


namespace Web.Api.Softijs.Services
{
    public interface IServicioRegister
    {
        Task<ResultadoBase> PostRegister([FromBody] Usuario u);
        Task<ResultadoBase> PutUsuario([FromBody] Usuario u);
    }
}
