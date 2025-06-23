namespace BiblioCleanSol.Application.Dtos.Usuarios
{
    public record UsuarioEditarDto : UsuarioDto
    {
        public int UsuarioId { get; set; }
        //Campos de auditoria
        public DateTime FechaMod { get; set; }
        public int UsuarioModId { get; set; }
    }
}
