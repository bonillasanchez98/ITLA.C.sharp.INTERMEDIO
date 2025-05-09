namespace SistemaGestionDeNomina.Entidades
{
    //Reciben un salario base, mas una comision por ventas. Recibiran un bono del 10% sobre el salario base
    public sealed class EmpleadoAsalariadoConComision : Empleado
    {
        public EmpleadoAsalariadoConComision(){}

        public EmpleadoAsalariadoConComision(string nombre, string apellido, string correo, string departamento, double sueldo, double ventasTotales) :
            base(nombre, apellido, correo, departamento)
        {
            _Sueldo = sueldo;
            _VentasTotales = ventasTotales;
        }

        public double _Sueldo { get; set; }
        public double _VentasTotales { get; set; }

        public override void CalcularPago()
        {
            double bono = _Sueldo * 0.10; //Aplicandole el 10% al sueldo fijo
            double comisionPorVentas = 0.05 * _VentasTotales; //Recibira un 5% de las ventas totales

            double sueldoTotal = bono + comisionPorVentas;

            Console.WriteLine($"SUELDO FIJO: ${_Sueldo}");
            Console.WriteLine($"10% BONIFICACION: ${bono}");
            Console.WriteLine($"VENTAS TOTALES: ${_VentasTotales}");
            Console.WriteLine($"COMISION x VENTAS: ${comisionPorVentas}");
            Console.WriteLine($"SUELDO TOTAL: ${sueldoTotal}");
        }
    }
}
