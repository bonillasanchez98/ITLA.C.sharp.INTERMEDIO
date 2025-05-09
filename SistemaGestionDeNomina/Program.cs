using SistemaGestionDeNomina.Entidades;

namespace SistemaGestionDeNomina
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========== Sistema de Gestion de Nomina por Empleados ==========\n");
            
            //Creando un empleado de tipo Asalariado
            Console.WriteLine("=====EMPLEADO ASALARIADO=====");
            EmpleadoAsalariado joseBonilla = new EmpleadoAsalariado("Jose", "Bonilla", "j.bonillaz@correo.com", "Soporte", 450);
            joseBonilla.CalcularPago();
            joseBonilla.MostrarInformacion();

            Console.WriteLine("");

            Console.WriteLine("=====EMPLEADO POR HORA=====");
            //Creando un empleado de tipo Empleado por hora
            EmpleadoPorHora peterParker = new EmpleadoPorHora("Peter", "Parker", "p.parker@correo.com", "Servicio al Cliente", 38);
            peterParker.CalcularPago();
            peterParker.MostrarInformacion();

            Console.WriteLine("");

            //Creando un empleado de tipo Empleado por comision
            Console.WriteLine("=====EMPLEADO POR COMISION=====");
            EmpleadoPorComision clarkKen = new EmpleadoPorComision("Clark", "Ken", "c.ken@correo.com", "Ventas", 15535);
            clarkKen.CalcularPago();
            clarkKen.MostrarInformacion();

            Console.WriteLine("");

            //Creando un empleado de tipo Asalariado con Comision
            Console.WriteLine("=====EMPLEADO ASALARIADO CON COMISION=====");
            EmpleadoAsalariadoConComision bruceBanner = new EmpleadoAsalariadoConComision("Bruce", "Banner", "b.banner@correo.com", "Negocios", 350, 14375);
            bruceBanner.CalcularPago();
            bruceBanner.MostrarInformacion();

        }
    }
}
