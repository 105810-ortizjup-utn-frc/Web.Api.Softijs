using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Api.Softijs.Commands;
using Web.Api.Softijs.Models;
using Web.Api.Softijs.Results;
using Web.Api.Softijs.Results.Login;

namespace Web.Api.Softijs.Services
{
    public interface IServicioLogin
    {
        List<Usuario> GetUsuarios();    
        Task<ActionResult<ResultadoLogin>> Login([FromBody]ComandoLogin comando);

        //void Agregar();
    }
}
