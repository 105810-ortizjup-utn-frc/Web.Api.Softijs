using Web.Api.Softijs.Models;

namespace Web.Api.Softijs.Commands.Ventas
{
    public class InformacionProductoDto
    {
        public int NroProducto { get; set; }
        public string Nombre { get; set; } = null!;
        public DateTime FechaVencimiento { get; set; }
        public Proveedore Proveedore { get; set; }
        public decimal Precio { get; set; }
        public string Lote { get; set; } = null!;
        public int PuntoNecesario { get; set; }
        public int PuntoOtorgado { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string ModificadoPor { get; set; } = null!;
        public DateTime FechaModificacion { get; set; }
        public UnidadesMedida UnidadMedida { get; set; }
        public Gusto Gusto { get; set; }
        public Marca Marca { get; set; }
        public string CreadoPor { get; set; } = null!;
        public Categoria Categoria { get; set; }
        public int Codigo { get; set; }

        public static implicit operator InformacionProductoDto(Producto entity)
        {
            if (entity == null)
                return null;

            return new InformacionProductoDto
            {
                NroProducto = entity.NroProducto,
                Nombre = entity.Nombre,
                FechaVencimiento = entity.FechaVencimiento,
                Proveedore = entity.IdProveedorNavigation,
                Precio = entity.Precio,
                Lote = entity.Lote,
                PuntoNecesario = entity.PuntoNecesario,
                PuntoOtorgado = entity.PuntoOtorgado,
                Activo = entity.Activo,
                FechaCreacion = entity.FechaCreacion,
                ModificadoPor = entity.ModificadoPor,
                FechaModificacion = entity.FechaModificacion,
                UnidadMedida = entity.IdUnidadMedidaNavigation,
                Gusto = entity.IdGustoNavigation,
                Marca = entity.IdMarcaNavigation,
                CreadoPor = entity.CreadoPor,
                Categoria = entity.IdCategoriaNavigation,
                Codigo = entity.Codigo
            };
        }
    }
}
