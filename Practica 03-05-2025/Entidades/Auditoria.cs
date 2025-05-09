namespace Practica_03_05_2025.Entidades
{
    public abstract class Auditoria
    {
        public DateTime CreationDate{ get; set; }
        public DateTime ModifyDate{ get; set; }
        public int UserMod{ get; set; }
        public int UserDeleted{ get; set; }
        public DateTime DeletedDate{ get; set; }
        public bool Deleted{ get; set; }

    }
}
