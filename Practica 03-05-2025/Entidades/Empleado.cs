namespace Practica_03_05_2025.Entidades
{
    public class Empleado : Persona
    {
        public double Sueldo { get; set; }
        public DateTime Horario { get; set; }
        public DateOnly FechaIngreso { get; set; }
        public string Puesto { get; set; }


        public override void ObtenerInformacion()
        {
            //Mostrar informacion del empleado
            throw new NotImplementedException();
        }

        public virtual void CalcularSueldo()
        {
            //Calcular el sueldo del empleado
            throw new NotImplementedException();
        }
        
    }
}
