namespace SistemaGestionDeNomina.Entidades
{
    //Reciben un sueldo fijo semanal sin considerar las horas trabajadas.
    public sealed class EmpleadoAsalariado : Empleado
    {
        public EmpleadoAsalariado(){}

        public EmpleadoAsalariado(string nombre, string apellido, string correo, string departamento, double sueldo) :
            base(nombre, apellido, correo, departamento)
        {
            _Sueldo = sueldo;
        }

        public double _Sueldo { get; set; }

        public override void CalcularPago()
        {
            Console.WriteLine($"SUELDO FIJO: ${_Sueldo}");
            
        }

    }
}
