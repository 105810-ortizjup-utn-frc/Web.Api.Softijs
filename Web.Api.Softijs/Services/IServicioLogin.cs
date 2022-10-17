using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Api.Softijs.Commands;
using Web.Api.Softijs.Models;
using Web.Api.Softijs.Results;


namespace Web.Api.Softijs.Services
{
    public interface IServicioLogin
    {
        List<Usuario> GetUsuarios();    
        Task<ActionResult<ResultadoBase>> Login([FromBody]ComandoLogin comando);

        //void Agregar();
    }
}
