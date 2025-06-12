using BiblioCleanSol.Domain.Base;

namespace BiblioCleanSol.Domain.Entities.Libros
{
    public sealed class Libro : Auditoria
    {
        public int LibroId { get; set; }
        public string Titulo { get; set; }
        public string ISBN { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public int CantEjemplares { get; set; }

        public int AutorId { get; set; }
        public int CategoriaId { get; set; }
        public int EstadoId { get; set; }
    }
}
