namespace BiblioCleanSol.Application.Dtos.Libros.Libros
{
    public record LibroAgregarDto : LibroDto
    {
        //Campos de auditoria
        public DateTime FechaCreacion { get; set; }
        public int UsuarioCreacionId { get; set; }
    }
}
