namespace BiblioCleanSol.Application.Dtos.Usuarios.Rol
{
    public record RolEditarDto : RolDto
    {
        public byte RolId { get; set; }
        //Campos de auditoria
        public DateTime FechaMod { get; set; }
        public int UsuarioModId { get; set; }
    }
}
