using BiblioCleanSol.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiblioCleanSol.Domain.Entities.Libros
{
    [Table("Categorias", Schema = "Core")]
    public sealed class Categoria : Auditoria
    {
        [Key]
        public int CategoraId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
