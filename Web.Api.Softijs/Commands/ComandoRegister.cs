namespace Web.Api.Softijs.Commands
{
    public class ComandoRegister
    {
        public string Nombre { set; get; }
        public string Email { get; set; }
        public string HashContrasenia { get; set; }
        public DateTime FechaCreacion { set; get; }
        public string ModificadoPor { set; get; }
        public DateTime FechaModificacion { set; get; }

    }
}
