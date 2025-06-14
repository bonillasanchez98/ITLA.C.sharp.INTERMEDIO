namespace BiblioCleanSol.Application.Dtos.Usuarios.Docente
{
    public record DocenteAgregarDto : DocenteDto
    {
        public DateTime FechaCreacion { get; set; }
        public int UsuarioCreacionId { get; set; }
    }
}
