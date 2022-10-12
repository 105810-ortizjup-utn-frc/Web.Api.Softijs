using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Api.Softijs.Commands
{
    public class ComandoProducto
    {
        public int Codigo { set; get; }
        public string Nombre { set; get; }
        public DateTime FechaVencimiento { set; get; }
        public int IdProveedor { set; get; }
        public decimal Precio { set; get; }
        public string Lote { set; get; }
        public int PuntosNecesarios { set; get; }
        public int PuntosOtorgados { set; get; }
        public bool Activo { set; get; }
        public DateTime FechaCreacion { set; get; }
        public string ModificadoPor { set; get; }
        public DateTime FechaModificacion { set; get; }
        public int IdUnidadMedida { set; get; }
        public int IdGusto { set; get; }
        public int IdMarca { set; get; }
        public string CreadoPor { set; get; }
        public int IdCategoria { set; get; }

    }
}
