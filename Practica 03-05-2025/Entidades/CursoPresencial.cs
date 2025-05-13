namespace Practica_03_05_2025.Entidades
{
    public sealed class CursoPresencial : Curso
    {
        public string Ubicacion { get; set; }
        public string Aula { get; set; }


        public override void Inscribirse(Estudiante estudiante)
        {
            //Logica de inscripcion de los cursos presenciales
            Console.WriteLine("Inscribiendo a estudiante en curso presencial");
        }

        public override string ObtenerInformacion()
        {
            return "Obteniendo Informacion de Cursos Virtuales";
        }
    }
}
