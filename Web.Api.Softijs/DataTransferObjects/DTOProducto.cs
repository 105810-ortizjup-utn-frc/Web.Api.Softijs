using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Api.Softijs.DataTransferObjects
{
    public class DTOProducto
    {

        public int nroProducto { set; get; }
        public int Codigo { set; get; }
        public string? nombre { set; get; }
        public DateTime FechaVencimiento { set; get; }
        public int IdProveedor { set; get; }
        public decimal Precio { set; get; }
        public string Lote { set; get; }
        public int PuntoNecesario
        { set; get; }
        public  int PuntoOtorgado
        { set; get; }
        public bool Activo
        { set; get; }
        public int IdUnidadMedida
        { set; get; }
        public int? IdGusto
        { set; get; }
        public int IdMarca
        { set; get; }
        public int IdCategoria 
        { set; get; }

        public int Categoria
        { set; get; }
        public  int Marca
        { set; get; }
        public int Gusto
        { set; get; }

    }
}
