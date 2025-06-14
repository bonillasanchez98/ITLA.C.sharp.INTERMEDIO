namespace BiblioCleanSol.Application.Dtos.Libros.Autor
{
    public record AutorEditarDto : AutorDto
    {
        public int AutorId { get; set; }
        //Campos de auditoria.
        public DateTime FechaMod { get; set; }
        public int UsuarioModId { get; set; }
    }
}
