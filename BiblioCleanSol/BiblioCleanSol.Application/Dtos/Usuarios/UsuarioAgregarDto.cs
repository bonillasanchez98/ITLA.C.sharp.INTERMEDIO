namespace BiblioCleanSol.Application.Dtos.Usuarios
{
    public record UsuarioAgregarDto : UsuarioDto
    {
        public DateTime FechaCreacion { get; set; }
        public int UsuarioCreacionId { get; set; }
    }
}
