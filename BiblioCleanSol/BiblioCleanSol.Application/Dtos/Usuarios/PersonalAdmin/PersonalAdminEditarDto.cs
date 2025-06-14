namespace BiblioCleanSol.Application.Dtos.Usuarios.PersonalAdmin
{
    public record PersonalAdminEditarDto : PersonalAdminDto
    {
        public int PersonalAdminId { get; set; }
        //Campos de auditoria
        public DateTime FechaMod { get; set; }
        public int UsuarioModId { get; set; }
    }
}
