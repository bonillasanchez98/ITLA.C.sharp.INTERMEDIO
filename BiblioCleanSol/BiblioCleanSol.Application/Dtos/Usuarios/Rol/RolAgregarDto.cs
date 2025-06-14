namespace BiblioCleanSol.Application.Dtos.Usuarios.Rol
{
    public record RolAgregarDto : RolDto
    {
        //Campos de auditoria
        public DateTime FechaCreacion { get; set; }
        public int UsuarioCreacionId { get; set; }
    }
}
