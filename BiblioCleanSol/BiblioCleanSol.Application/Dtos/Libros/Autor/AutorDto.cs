namespace BiblioCleanSol.Application.Dtos.Libros.Autor
{
    /// <summary>
    /// En este record estaran los campos base de Autor.
    /// </summary>
    public record AutorDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Nacionalidad { get; set; } = string.Empty;

        public bool Habilitado { get; set; }
    }
}
