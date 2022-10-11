using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Api.Softijs.Models;

namespace Web.Api.Softijs.Services
{
    public interface IServicioMarcas
    {
        List<Marca> GetMarcas();
    }
}
