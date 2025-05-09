
namespace SistemaGestionDeNomina.Entidades
{
    //Ganan segun las horas trabajadas y reciben pago adicional por horas extras si exceden las 40 horas.
    public sealed class EmpleadoPorHora : Empleado
    {
        public EmpleadoPorHora(){}

        public EmpleadoPorHora(string nombre, string apellido, string correo, string departamento, int horasTrabajadas) :
            base(nombre, apellido, correo, departamento)
        {
            this._HorasTrabajadas = horasTrabajadas;
        }

        public int _HorasTrabajadas { get; set; }
        private double _Sueldo { get; set; }

        public override void CalcularPago()
        {
            bool esHoraExtra = _HorasTrabajadas < 40 && _HorasTrabajadas > 0;
            _Sueldo = _HorasTrabajadas * 6; // 6 = dias trabajados en la semana
            
            if (esHoraExtra)
            {
                Console.WriteLine($"TOTAL HORAS: {_HorasTrabajadas}h");
                Console.WriteLine($"SUELDO: ${_Sueldo}");
            }

            else
            {
                Console.WriteLine($"HORAS TRABAJADAS: {_HorasTrabajadas}");
                Console.WriteLine($"SUELDO: ${_Sueldo} --> *Recibe pago extra*");
            }
        }
    }
}
