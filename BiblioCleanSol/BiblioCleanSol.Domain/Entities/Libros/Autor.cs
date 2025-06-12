using BiblioCleanSol.Domain.Base;

namespace BiblioCleanSol.Domain.Entities.Libros
{
    public sealed class Autor : Auditoria
    {
        public int AutorId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Nacionalidad { get; set; }
    }
}
