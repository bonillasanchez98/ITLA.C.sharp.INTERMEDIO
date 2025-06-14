namespace BiblioCleanSol.Application.Dtos.Libros.Categoria
{
    public record CategoriaAgregarDto : CategoriaDto
    {
        //Campos de auditoria
        public DateTime FechaCreacion { get; set; }
        public int UsuarioCreacionId { get; set; }
    }
}
