using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Api.Softijs.DataTransferObjects;

namespace Web.Api.Softijs.Services
{
    public interface IServicioReportes
    {
        Task<List<DTORendimientoVendedor>> GetRedimientoVendedor(int id);
        Task<List<DTORendimientoVendedor>> GetMontoTotal(int id);
        Task<List<DTOFacturacionDiaria>> GetTotalVendidoDiario();
        Task<List<DTOReporteLiquidaciones>> GetLiquidacionesEmpleados();
        Task<List<DTOCantXCat>> GetCantXCat();
        Task<List<DTOEstadisticaClientes>> GetEstadisticaClientes();
    }
}
