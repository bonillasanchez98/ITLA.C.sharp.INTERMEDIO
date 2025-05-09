namespace Practica_03_05_2025.Entidades
{
    public sealed class CursoPresencial : Curso
    {
        public string Ubicacion { get; set; }
        public string Dias { get; set; }
        public int HoraInicio { get; set; }
        public int HoraFin{ get; set; }

        public override string ObtenerInformacion()
        {
            return "Obteniendo Informacion de Cursos Virtuales";
        }
    }
}
