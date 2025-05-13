
namespace Practica_03_05_2025.Entidades
{
    public abstract class Curso : Auditoria
    {
        public string Titulo { get; set; }
        public int Creditos{ get; set; }
        public string Departamento { get; set; }
        public string Dias { get; set; }
        public int HoraInicio { get; set; }
        public int HoraFin { get; set; }

        public abstract string ObtenerInformacion();

        public abstract void Inscribirse(Estudiante estudiante);
    }
}
