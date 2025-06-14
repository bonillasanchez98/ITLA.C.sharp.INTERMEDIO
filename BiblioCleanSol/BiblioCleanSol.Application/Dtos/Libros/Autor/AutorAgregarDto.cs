namespace BiblioCleanSol.Application.Dtos.Libros.Autor
{
    public record AutorAgregarDto : AutorDto
    {
        //Campos de auditoria.
        public DateTime FechaCreacion { get; set; }
        public int UsuarioCreacionId { get; set; }
    }
}
