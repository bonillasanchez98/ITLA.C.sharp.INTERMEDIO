namespace SistemaGestionDeNomina.Entidades
{
    //Reciben un salario base, mas una comision por ventas. Recibiran un bono del 10% sobre el salario base
    public sealed class EmpleadoAsalariadoConComision : EmpleadoPorComision
    {
        private double Bono = 0.0;
        private double ComisionPorVentas = 0.0;
        private double SueldoTotal  = 0.0;


        public override double CalcularPago()
        {
            Bono = _Sueldo * 0.10; //Aplicandole el 10% al sueldo fijo
            ComisionPorVentas = 0.05 * _VentasTotales; //Recibira un 5% de las ventas totales

            SueldoTotal = Bono + ComisionPorVentas;

            return SueldoTotal;
        }

        public override void MostrarInformacion()
        {
            Console.WriteLine("=====EMPLEADO ASALARIADO CON COMISION=====");
            Console.WriteLine($"NOMBRE: {_Nombre} {_Apellido}\n" +
                              $"CORREO: {_Correo}\n" +
                              $"DEPARTAMENTO: {_Departamento}\n" +
                              $"SUELDO FIJO: ${_Sueldo}\n" +
                              $"******EXTRA******\n" +
                              $"10% BONIFICACION: ${Bono}\n" +
                              $"COMISION X VENTAS: ${ComisionPorVentas}\n" +
                              $"******************\n" +
                              $"SUELDO TORAL: ${SueldoTotal}\n");
            Console.ReadLine();
            
        }
    }
}
