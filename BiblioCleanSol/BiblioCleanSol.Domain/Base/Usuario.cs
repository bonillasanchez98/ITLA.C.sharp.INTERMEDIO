using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiblioCleanSol.Domain.Base
{
    [Table("Usuarios", Schema = "Seguridad")]
    public abstract class Usuario : Auditoria
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }

        public int Rol_id { get; set; }
    }
}
