namespace SistemaGestionDeNomina.Entidades
{
    //Obtienen su sueldo segun un porcentaje del 5% de las ventas totales que tenga.
    public abstract class EmpleadoPorComision : Empleado
    {
        public double _VentasTotales { get; set; }

        public override double CalcularPago()
        {
            _Sueldo = 0.05 * _VentasTotales;
            return _Sueldo;
        }

        public override void MostrarInformacion()
        {
            Console.WriteLine($"NOMBRE: {_Nombre} {_Apellido}\n" +
                              $"CORREO: {_Correo}\n" +
                              $"DEPARTAMENTO: {_Departamento}\n" +
                              $"VENTAS TOTALES: ${_VentasTotales}\n" +
                              $"SUELDO: ${_Sueldo}");
            Console.ReadLine();
        }
    }
}
