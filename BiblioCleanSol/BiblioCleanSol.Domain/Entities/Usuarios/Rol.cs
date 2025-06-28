using BiblioCleanSol.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiblioCleanSol.Domain.Entities.Seguridad
{
    [Table("Roles", Schema = "Seguridad")]
    public sealed class Rol : Auditoria
    {
        [Key]
        [Column("id_Rol")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte RolId { get; set; }
        
        public string Nombre { get; set; }
    }
}
