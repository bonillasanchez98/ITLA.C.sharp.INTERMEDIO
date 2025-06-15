namespace BiblioCleanSol.Application.Dtos.Libros.Categoria
{
    /// <summary>
    /// En este record estaran los campos base de Categoria.
    /// </summary>
    public record CategoriaDto
    {
        public string Nombre { get; set; } = String.Empty;
        public string Descripcion { get; set;} = String.Empty;

        public bool Habilitado { get; set; }
    }
}
