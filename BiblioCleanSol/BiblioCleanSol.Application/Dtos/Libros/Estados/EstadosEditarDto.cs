namespace BiblioCleanSol.Application.Dtos.Libros.Estados
{
    public record EstadosEditarDto : EstadosDto
    {
        public int EstadoId { get; set; }
        //Campos de auditoria
        public DateTime FechaMod { get; set; }
        public int UsuarioModId { get; set; }
    }
}
