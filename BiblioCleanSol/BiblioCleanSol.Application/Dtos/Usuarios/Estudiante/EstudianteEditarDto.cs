namespace BiblioCleanSol.Application.Dtos.Usuarios.Estudiante
{
    public record EstudianteEditarDto : EstudianteDto
    {
        public int EstudianteId { get; set; }
        //Campos de auditoria
        public DateTime FechaMod { get; set; }
        public int UsuarioModId { get; set; }
    }
}
