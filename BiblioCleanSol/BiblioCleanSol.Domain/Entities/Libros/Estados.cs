using BiblioCleanSol.Domain.Base;

namespace BiblioCleanSol.Domain.Entities.Libros
{
    public sealed class Estados : Auditoria
    {
        public int EstadoId { get; set; }
        public string Estado { get; set; } //Este atributo representa el nombre que tendra el estado.
        public string Descripcion { get; set; }
    }
}
