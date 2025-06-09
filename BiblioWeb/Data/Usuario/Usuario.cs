namespace BiblioWeb.Data.Usuario
{
    public class Usuario
    {
        public int id_Usuario { get; set; }
        public int Rol_id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
    }
}
