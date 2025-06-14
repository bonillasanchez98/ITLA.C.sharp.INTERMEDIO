namespace BiblioCleanSol.Application.Dtos.Usuarios.Estudiante
{
    public record EstudianteDto
    {
        public string Nombre { get; set; } = String.Empty;
        public string Apellido { get; set; } = String.Empty;
        public string Correo { get; set; } = String.Empty;
        public string Clave { get; set; } = String.Empty;
        public int RolId { get; set; }

        public bool Habilitado { get; set; }
    }
}
