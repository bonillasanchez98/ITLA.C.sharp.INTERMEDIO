namespace BiblioCleanSol.Application.Dtos.Usuarios.PersonalAdmin
{
    public record PersonalAdminAgregarDto : PersonalAdminDto
    {
        //Campos de auditoria
        public DateTime FechaCreacion { get; set; }
        public int UsuarioCreacionId { get; set; }
    }
}
