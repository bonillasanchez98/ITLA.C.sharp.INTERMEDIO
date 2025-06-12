using BiblioCleanSol.Domain.Base;

namespace BiblioCleanSol.Domain.Entities.Libros
{
    public sealed class Categoria : Auditoria
    {
        public int CategoraId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
