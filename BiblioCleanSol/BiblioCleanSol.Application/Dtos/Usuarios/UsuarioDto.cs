namespace BiblioCleanSol.Application.Dtos.Usuarios
{
    public record UsuarioDto
    {
        public string Nombre { get; set; } = String.Empty;
        public string Apellido { get; set; } = String.Empty;
        public string Correo { get; set; } = String.Empty;
        public string Clave { get; set; } = String.Empty;

        public int Rol_id { get; set; }
        public bool Habilitado { get; set; }

    }
}
