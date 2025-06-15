using BiblioCleanSol.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiblioCleanSol.Domain.Entities.Libros
{
    [Table("Estados", Schema = "Core")]
    public sealed class Estados : Auditoria
    {
        [Key]
        public int EstadoId { get; set; }
        public string Estado { get; set; } //Este atributo representa el nombre que tendra el estado.
        public string Descripcion { get; set; }
    }
}
