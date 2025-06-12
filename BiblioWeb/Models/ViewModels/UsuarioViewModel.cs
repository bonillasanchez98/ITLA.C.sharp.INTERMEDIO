using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BiblioWeb.Models.ViewModels
{
    public class UsuarioViewModel
    {
        //public int id_Usuario { get; set; }
        [Required(ErrorMessage = "El rol es requerido.")]
        public int Rol_id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Correo { get; set; }
        [Required]
        public string Clave { get; set; }

        public string SelectedRol { get; set; }

        public List<SelectListItem> RolSelectList { get; set; } = new List<SelectListItem>();
    }
}
