using BiblioWeb.Data.Rol;

namespace BiblioWeb.Helper
{
    public static class RolesHelper
    {
        public static List<Rol> GetRols()
        {
            return new List<Rol> { 
                new Rol(){id_Rol = 2, Nombre = "ADMIN"},
                new Rol(){id_Rol = 3, Nombre = "ESTUDIANTES"},
                new Rol(){id_Rol = 4, Nombre = "DOCENTES"}
            };
        }
    }
}
