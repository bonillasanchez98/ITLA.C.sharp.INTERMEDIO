using BiblioCleanSol.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiblioCleanSol.Domain.Entities.Prestamo
{
    [Table("Prestamos", Schema = "Core")]
    public sealed class Prestamo : Auditoria
    {
        public int PrestamoId { get; set; }
        public string Codigo { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public DateTime FechaRealDevolucion { get; set; }

        public int LibroId { get; set; }
        public int UsuarioId { get; set; }
    }
}
