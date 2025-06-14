namespace BiblioCleanSol.Application.Dtos.Usuarios.Estudiante
{
    public record EstudianteAgregarDto : EstudianteDto
    {
        public DateTime FechaCreacion { get; set; }
        public int UsuarioCreacionId { get; set; }
    }
}
