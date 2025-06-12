using BiblioCleanSol.Domain.Base;

namespace BiblioCleanSol.Domain.Entities.Seguridad
{
    public sealed class Rol : Auditoria
    {
        public int RolId { get; set; }
        public string Nombre { get; set; }
    }
}
