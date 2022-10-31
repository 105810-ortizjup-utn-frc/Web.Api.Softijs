using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Web.Api.Softijs.Models;
using Web.Api.Softijs.Results;

namespace Web.Api.Softijs.Commands
{
    public class ComandoLogin
    {
        public int IdUsuario { get; set; }
        #region Command
        [Required(ErrorMessage = "El email es requerido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contrseña es requerida")]
        public string Contrasenia { get; set; }
        #endregion

        #region Response
        public bool Activo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string[] Roles { get; set; } 
        public string Token { get; set; }
        #endregion

        #region Resultado Base
        public string Message { set; get; } = null!;
        public bool Ok { set; get; }
        public string Error { get; set; }
        public int CodigoEstado { set; get; }
        #endregion

        public static implicit operator ComandoLogin(Usuario user)
        {
            if (user == null)
                return null;

            return new ComandoLogin
            { 
                IdUsuario = user.IdUsuario,
                Activo = user.Activo,
                Email = user.Email,
                Nombre = user.Nombre,
                Apellido = user.Apellido,
                Roles = user.UsuariosRoles.Select(s => s.IdRolNavigation.Codigo).ToArray()
            };
        }
    }
}