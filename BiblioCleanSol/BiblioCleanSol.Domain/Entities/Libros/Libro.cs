using BiblioCleanSol.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiblioCleanSol.Domain.Entities.Libros
{
    [Table("Libros", Schema = "Core")]
    public sealed class Libro : Auditoria
    {
        [Key]
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
