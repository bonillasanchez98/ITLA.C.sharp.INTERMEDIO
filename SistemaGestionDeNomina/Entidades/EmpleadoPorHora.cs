namespace SistemaGestionDeNomina.Entidades
{
    //Ganan segun las horas trabajadas y reciben pago adicional por horas extras si exceden las 40 horas.
    public sealed class EmpleadoPorHora : Empleado
    {
        public EmpleadoPorHora(){}

        public int _HorasTrabajadas { get; set; }

        public override double CalcularPago()
        {
            bool noEsHoraExtra = _HorasTrabajadas < 40 && _HorasTrabajadas > 0;
            _Sueldo = _HorasTrabajadas * 6; // 6 = dias trabajados en la semana
            
            if (noEsHoraExtra) //Si no supera las 40h de trabajo, se retorna su sueldo segun las horas trabajadas
            {
                return _Sueldo;
            }
            else //Si hizo horas extras, se le agregara un pago de $60.0 al sueldo
            {
                _Sueldo = (_HorasTrabajadas * 6) + 60.0; 
                return _Sueldo;
            }
        }

        public override void MostrarInformacion()
        {
            Console.WriteLine("=====EMPLEADO POR HORA=====");
            Console.WriteLine($"NOMBRE: {_Nombre} {_Apellido}\n" +
                              $"CORREO: {_Correo}\n" +
                              $"DEPARTAMENTO: {_Departamento}\n" +
                              $"HORAS TRABAJADAS: {_HorasTrabajadas}h\n" +
                              $"SUELDO: ${_Sueldo}");
            Console.ReadLine();
        }
    }
}
