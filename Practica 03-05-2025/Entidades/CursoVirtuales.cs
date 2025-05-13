namespace Practica_03_05_2025.Entidades
{
    public sealed class CursoVirtuales : Curso
    {
        public string URL { get; set; }

        public override void Inscribirse(Estudiante estudiante)
        {   //Logica de inscripcion de los cursos virtuales
            Console.WriteLine("Inscribiendo estudiante en curso virtual");
        }

        public override string ObtenerInformacion()
        {
            return "Obteniendo Informacion de Cursos Virtuales";
        }
    }
}
