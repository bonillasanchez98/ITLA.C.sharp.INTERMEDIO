namespace BiblioCleanSol.Application.Dtos.Libros.Libros
{
    public record LibroDto
    {
        public string Titulo { get; set; } = String.Empty;
        public string ISBN { get; set; } = string.Empty;
        public DateTime FechaPublicacion { get; set; }
        public int CantEjemplares { get; set; }
        public int AutorId { get; set; }
        public int CategoriaId { get; set; }
        public int EstadoId { get; set; }

        public bool Habilitado { get; set; }
    }
}
