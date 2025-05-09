namespace SistemaGestionDeNomina.Entidades
{
    //Obtienen su sueldo segun un porcentaje del 5% de las ventas totales que tenga.
    public sealed class EmpleadoPorComision : Empleado
    {
        public EmpleadoPorComision(){}

        public EmpleadoPorComision(string nombre, string apellido, string correo, string departamento, double ventasTotales) :
            base(nombre, apellido, correo, departamento)
        {
            _VentasTotales = ventasTotales;
        }

        public double _VentasTotales { get; set; }
        private double _Sueldo { get; set; }


        public override void CalcularPago()
        {
            _Sueldo = 0.05 * _VentasTotales;

            Console.WriteLine($"VENTAS TOTALES: ${_VentasTotales}");
            Console.WriteLine($"SUELDO: ${_Sueldo}");
        }
    }
}
