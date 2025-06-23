using BiblioCleanSol.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiblioCleanSol.Domain.Entities.Libros
{
    [Table("Autores", Schema = "Core")]
    public sealed class Autor : Auditoria
    {
        [Key]
        [Column("id_Autor")]
        public int AutorId { get; set; }
        public string Nombre { get; set; }
        public string? Apellido { get; set; }
        public string Nacionalidad { get; set; }
    }
}
