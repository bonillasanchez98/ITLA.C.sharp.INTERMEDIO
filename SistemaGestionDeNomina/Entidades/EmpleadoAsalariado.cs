using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SistemaGestionDeNomina.Entidades
{
    //Reciben un sueldo fijo semanal sin considerar las horas trabajadas.
    public sealed class EmpleadoAsalariado : Empleado
    {
        public EmpleadoAsalariado(){}

        public EmpleadoAsalariado(string nombre, string apellido, string correo, string departamento, double sueldo) :
            base(nombre, apellido, correo, departamento, sueldo)
        {
           
        }

        public override double CalcularPago()
        {
            return _Sueldo;
        }

        public override void MostrarInformacion()
        {
            Console.WriteLine("=====EMPLEADO ASALARIADO=====");
            Console.WriteLine($"NOMBRE: {_Nombre} {_Apellido}\n" +
                              $"CORREO: {_Correo}\n" +
                              $"DEPARTAMENTO: {_Departamento}\n"+
                              $"SUELDO FIJO: ${_Sueldo}");
            Console.ReadLine();
        }
    }
}
