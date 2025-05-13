namespace SistemaGestionDeNomina.Entidades
{
    public sealed class EmpleadoPorComisionNormal : EmpleadoPorComision
    {

        public override double CalcularPago()
        {
            return base.CalcularPago();
        }

        public override void MostrarInformacion()
        {
            Console.WriteLine("=====EMPLEADO POR COMISION=====");
            base.MostrarInformacion();
        }

    }
}
