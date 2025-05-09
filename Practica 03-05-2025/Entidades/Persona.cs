namespace Practica_03_05_2025.Entidades
{
    public abstract class Persona : Auditoria
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Cedula { get; set; }
        public string Direccion { get; set; }
        public string Genero { get; set; }
        public DateOnly FechaNacimiento { get; set; }
        public int Telefono { get; set; }

        public abstract void ObtenerInformacion();
    }
}
