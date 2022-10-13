namespace Web.Api.Softijs.Commands
{
    public class ComandoRegister
    {
        public string Nombre { set; get; }
        public string Email { get; set; }
        public string HashContrasenia { get; set; }
        public int IdTipoUsuario { get; set; }
        public bool Activo { get; set; }
        public string CreadoPor { set; get; }
        public DateTime FechaCreacion { set; get; }
        public string ModificadoPor { set; get; }
        public DateTime FechaModificacion { set; get; }

    }
}
