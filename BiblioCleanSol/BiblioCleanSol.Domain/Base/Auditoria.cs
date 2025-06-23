using System.ComponentModel.DataAnnotations.Schema;

namespace BiblioCleanSol.Domain.Base
{
    public abstract class Auditoria
    {
        public DateTime? fecha_creacion { get; set; }

        public int? usuario_creacion_id { get; set; }

        public DateTime? fecha_mod { get; set; }

        public int? usuario_mod { get; set; }
        
        public DateTime? fecha_elim { get; set; }

        public int? usuario_elim_id { get; set; }

        public bool elimino { get; set; }
    }
}
