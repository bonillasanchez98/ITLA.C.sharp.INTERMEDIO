namespace BiblioCleanSol.Domain.Base
{
    public abstract class Auditoria
    {
        public DateTime FechaCreacion { get; set; }
        public int UsuarioCreacionId { get; set; }
        public DateTime FechaMod { get; set; }
        public int UsuarioModId { get; set; }
        public DateTime FechaElimino { get; set; }
        public int UsuarioEliminoId { get; set; }
        public bool Habilitado { get; set; }
    }
}
