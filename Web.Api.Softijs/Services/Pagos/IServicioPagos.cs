﻿using Web.Api.Softijs.DataTransferObjects;
using Web.Api.Softijs.Models;

namespace Web.Api.Softijs.Services.Pagos
{
    public interface IServicioPagos
    {

        Task<List<DTOordenP>> GetOrdenP();

        Task<List<DTOPagosPendientes>> GetPagosPendientes();

    }
}
