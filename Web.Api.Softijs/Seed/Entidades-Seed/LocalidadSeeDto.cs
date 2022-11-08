namespace Web.Api.Softijs.Seed.Entidades_Seed
{
    public class LocalidadSeeDto
    {
        public string Categoria { get; set; }   
        public string Fuente { get; set; }
        public string Nombre { get; set; }
        public DepartamentoSeedDto Departamento { get; set; }
        public ProvinciaSeedDto Provincia { get; set; }
    }
}
