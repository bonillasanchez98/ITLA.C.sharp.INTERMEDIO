namespace BiblioCleanSol.Application.Dtos.Libros.Libros
{
    public record LibroEditarDto : LibroDto
    {
        public int LibroId { get; set; }
        //Campos de auditoria
        public DateTime FechaMod { get; set; }
        public int UsuarioModId { get; set; }
    }
}
