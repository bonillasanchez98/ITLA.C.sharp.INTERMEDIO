namespace BiblioCleanSol.Application.Dtos.Usuarios.Rol
{
    public record RolDto
    {
        public string Nombre { get; set; } = String.Empty;

        public bool Habilitado { get; set; }
    }
}
