using BiblioCleanSol.Domain.Base;

namespace BiblioCleanSol.Domain.Entities.Prestamo
{
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
