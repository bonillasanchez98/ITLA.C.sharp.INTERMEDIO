using BiblioCleanSol.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiblioCleanSol.Domain.Entities.Prestamo
{
    [Table("Prestamos", Schema = "Core")]
    public sealed class Prestamo : Auditoria
    {
        [Key]
        [Column("id_Prestamo")]
        public int PrestamoId { get; set; }
        
        [Column("Codigo_prestamo")]
        public string Codigo { get; set; }

        [Column("Fecha_prestamo")]
        public DateTime? FechaPrestamo { get; set; }


        [Column("Fecha_devolucion")]
        public DateTime? FechaDevolucion { get; set; }
        
        [Column("Fecha_real_devolucion")]
        public DateTime? FechaRealDevolucion { get; set; }

        [Column("Libro_id")]
        [ForeignKey("Libros")]
        public int LibroId { get; set; }

        [Column("Usuario_id")]
        public int UsuarioId { get; set; }
    }
}
