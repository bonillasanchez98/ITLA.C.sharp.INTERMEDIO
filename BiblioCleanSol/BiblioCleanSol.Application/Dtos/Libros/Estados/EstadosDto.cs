namespace BiblioCleanSol.Application.Dtos.Libros.Estados
{
    public record EstadosDto
    {
        //Este atributo representa el nombre que tendra el estado
        public string Estado { get; set; } = String.Empty;
        public string Descripcion { get; set; } = String.Empty;

        public bool Habilitado { get; set; }
    }
}
