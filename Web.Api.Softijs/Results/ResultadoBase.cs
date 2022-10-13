namespace Web.Api.Softijs.Results
{
    public class ResultadoBase
    {
        public string Message { set; get; } = null!;
        public bool Ok { set; get; }
        public int CodigoEstado { set; get; }
    }
}
