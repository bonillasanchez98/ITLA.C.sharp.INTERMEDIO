namespace BiblioCleanSol.Application.Dtos.Libros.Estados
{
    record class EstadosAgregarDto : EstadosDto
    {
        //Campos de auditoria
        public DateTime FechaCreacion { get; set; }
        public int UsuarioCreacionId { get; set; }
    }
}
