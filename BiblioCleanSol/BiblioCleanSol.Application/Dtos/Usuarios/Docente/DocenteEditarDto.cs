namespace BiblioCleanSol.Application.Dtos.Usuarios.Docente
{
    public record DocenteEditarDto : DocenteDto
    {
        public int DocenteId { get; set; }
        //Campos de auditoria
        public DateTime FechaMod { get; set; }
        public int UsuarioModId { get; set; }
    }
}
