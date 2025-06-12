using Microsoft.AspNetCore.Mvc.Rendering;

namespace BiblioWeb.Data.Usuario
{
    public class Usuario
    {
        public int id_Usuario { get; set; }
        public int Rol_id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }

        public string SelectedRol { get; set; }
        public List<SelectListItem> RolSelectList { get; set; } = new List<SelectListItem>();
    }
}
