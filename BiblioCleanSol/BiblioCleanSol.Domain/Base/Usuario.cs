namespace BiblioCleanSol.Domain.Base
{
    public abstract class Usuario : Auditoria
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }

        public int Rol_id { get; set; }
    }
}
