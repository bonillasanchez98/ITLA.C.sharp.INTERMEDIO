using BiblioCleanSol.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiblioCleanSol.Domain.Entities.Libros
{
    [Table("Libros", Schema = "Core")]
    public sealed class Libro : Auditoria
    {
        [Key]
        [Column("id_Libro")]
        public int LibroId { get; set; }
        public string Titulo { get; set; }
        public string? ISBN { get; set; }
        [Column("Fecha_publicacion")]
        public DateTime? FechaPublicacion { get; set; }
        [Column("Cantidad_ejemplares")]
        public int? CantEjemplares { get; set; }

        [Column("Autor_id")]
        public int AutorId { get; set; }
        [Column("Categoria_id")]
        public int CategoriaId { get; set; }
        [Column("Estado_id")]
        public int EstadoId { get; set; }
    }
}
