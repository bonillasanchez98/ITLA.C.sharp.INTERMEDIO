namespace Practica_03_05_2025.Entidades
{
    public sealed class Docente : Empleado
    {
        public string Materia { get; set; }
        public string Grado { get; set; }


        public override void ObtenerInformacion()
        {   //Mostrar Informacion del Docente
            base.ObtenerInformacion();
        }

        public override void CalcularSueldo()
        {   //Calcular el sueldo del Docente
            base.CalcularSueldo();
        }
    }
}
