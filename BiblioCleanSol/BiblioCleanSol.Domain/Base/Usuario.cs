using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiblioCleanSol.Domain.Base
{
    [Table("Usuarios", Schema = "Seguridad")]
    public sealed class Usuario : Auditoria
    {
        [Key]
        [Column("id_Usuario")]
        public int UsuarioId { get; set; }

        [Column("Nombre")]
        public string Nombre { get; set; }
        
        [Column("Apellido")]
        public string Apellido { get; set; }

        [Column("Correo")]
        public string Correo { get; set; }

        [Column("Clave")]
        public string Clave { get; set; }

        [Column("Rol_id")]
        public byte Rol_id { get; set; }
    }
}
