namespace BiblioCleanSol.Application.Dtos.Libros.Categoria
{
    public record CategoriaEditarDto : CategoriaDto
    {
        public int CategoriaId { get; set; }
        //Campos de auditoria
        public DateTime FechaMod { get; set; }
        public int UsuarioModId { get; set; }
    }
}
