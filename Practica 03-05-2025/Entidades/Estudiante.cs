namespace Practica_03_05_2025.Entidades
{
    public sealed class Estudiante : Persona
    {
        public string Grado { get; set; }
        public string Carrera { get; set; }
        public double Promedio { get; set; }
        public DateOnly FechaIngreso { get; set; }
        public string CodigoEstudiante { get; set; }
        public bool Estatus { get; set; }

        public override void ObtenerInformacion()
        {   
            //Mostrar informacion del estudiante
            throw new NotImplementedException();
        }
        public void ObtenerPromedio()
        {
            //Obtener el promedio del estudiante
            throw new NotImplementedException();
        }
    }
}
