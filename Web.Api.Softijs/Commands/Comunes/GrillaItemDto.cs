namespace Web.Api.Softijs.Commands.Comunes
{
    public class GrillaItemDto
    {
        public int PaginaActual { get; set; }
        public int CantidadPaginas { get; set; }
        public int CantidadMaximaDeItemsPorPagina { get; set; }
        public List<object> gridItems { get; set; }
    }
}
