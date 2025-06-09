using Microsoft.AspNetCore.Mvc.Rendering;

namespace BiblioWeb.Models.ViewModels
{
    public class UsuarioViewModel
    {
        public string SelectedRol { get; set; }

        public List<SelectListItem> RolSelectList { get; set; }
    }
}
