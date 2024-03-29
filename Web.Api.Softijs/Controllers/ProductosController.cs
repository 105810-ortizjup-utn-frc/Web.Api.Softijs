﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Softijs.Commands;
using Web.Api.Softijs.DataContext;
using Web.Api.Softijs.DataTransferObjects;
using Web.Api.Softijs.Models;
using Web.Api.Softijs.Results;
using Web.Api.Softijs.Services;
using Web.Api.Softijs.Services.Security;

namespace Web.Api.Softijs.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IServicioProductos servicio;
        private readonly ISecurityService _securityService;

        public ProductosController(IServicioProductos _servicio, SoftijsDevContext _contextm, ISecurityService securityService)
        {
            this.servicio = _servicio;
            _securityService = securityService;
        }

        [HttpGet("getPrecioProductoByProductoId/{id}")]
        public async Task<IActionResult> GetPrecioProductoByProductoId(int id)
        {
            return Ok(await servicio.GetInformacionProductoDtoById(id));
        }

        [HttpGet("getProductosForComboBox")]
        public async Task<ActionResult> GetProductosForCoboBox()
        {
            return Ok(await servicio.GetProductosForComboBox());
        }

        [HttpGet("GetProductos")]
        public async Task<ActionResult> GetProductos()
        {
            return Ok(await this.servicio.GetProductos());
        }

        [HttpPost("PostProducto")]
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
            p.Codigo = comando.Codigo;

            return Ok(await this.servicio.PostProducto(p));
        }


        [HttpPut("PutProducto")]

        public async Task<ActionResult<ResultadoBase>> PutProducto([FromBody] DTOProducto comando)
        {
            DTOProducto p = new DTOProducto();
            p.FechaVencimiento = comando.FechaVencimiento;
            p.IdProveedor = comando.IdProveedor;
            p.Precio = comando.Precio;
            p.Lote = comando.Lote;
            p.PuntoNecesario = comando.PuntoNecesario;
            p.PuntoOtorgado = comando.PuntoOtorgado;
            p.Activo = comando.Activo;
            p.IdUnidadMedida = comando.IdUnidadMedida;
            p.IdGusto = comando.IdGusto;
            p.IdMarca = comando.IdMarca;
            p.IdCategoria = comando.IdCategoria;
            p.Codigo = comando.Codigo;

            return Ok(await this.servicio.PutProducto(p));
        }


        [HttpDelete]
        [Route("DeleteProducto/{id}")]

        public async Task<ActionResult<ResultadoBase>> DeleteProducto(int id)
        {
            if (!_securityService.CheckUserHasroles(new string[] { "Admin" }))
                return StatusCode(StatusCodes.Status403Forbidden, "No tiene los permisos para ejecutar esta acción.");

            return Ok(await this.servicio.DeleteProducto(id));
        }

        [HttpPut]
        [Route("ActivarProducto/{id}")]

        public async Task<ActionResult<ResultadoBase>> ActivarProducto(int id)
        {

            return Ok(await this.servicio.ActivarProducto(id));
        }

        [HttpGet]
        [Route("GetProductoById/{id}")]

        public async Task<ActionResult<ResultadoBase>> GetProductoById(int id)
        {
            return Ok(await this.servicio.GetProductoById(id));
        }
    }
}
