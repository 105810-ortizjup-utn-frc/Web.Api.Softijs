using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Api.Softijs.Commands;
using Web.Api.Softijs.DataContext;
using Web.Api.Softijs.Models;
using Web.Api.Softijs.Results;
using Web.Api.Softijs.Services;

namespace Web.Api.Softijs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IServicioProductos servicio;
        private readonly SoftijsDevContext context;
        public ProductosController(IServicioProductos _servicio, SoftijsDevContext _context)
        {
            this.servicio = _servicio;
            this.context = _context;
        }

        [HttpGet]
        [Route("GetProductos")]

        public async Task<ActionResult> GetProductos()
        {
            return Ok(this.servicio.GetProductos());
        }

        [HttpPost]
        [Route("PostProducto")]

        public async Task<ActionResult<ResultadoBase>> PostProducto([FromBody] ComandoProducto comando)
        {
            Producto p = new Producto();
            p.Nombre = comando.Nombre;
            p.FechaVencimiento = comando.FechaVencimiento;
            p.IdProveedor = comando.IdProveedor;
            p.Precio = comando.Precio;
            p.Lote = comando.Lote;
            p.PuntoNecesario = comando.PuntosNecesarios;
            p.PuntoOtorgado = comando.PuntosOtorgados;
            p.Activo = comando.Activo;
            p.IdUnidadMedida = comando.IdUnidadMedida;
            p.IdGusto = comando.IdGusto;
            p.IdMarca = comando.IdMarca;
            p.IdCategoria = comando.IdCategoria;
            p.CreadoPor = comando.CreadoPor;
            p.ModificadoPor = comando.ModificadoPor;
            p.FechaCreacion = comando.FechaCreacion;
            p.FechaModificacion = comando.FechaModificacion;

            return Ok(this.servicio.PostProducto(p));
        }
    }
}
