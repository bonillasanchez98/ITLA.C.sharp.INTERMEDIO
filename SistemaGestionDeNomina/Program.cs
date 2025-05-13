using SistemaGestionDeNomina.Entidades;

namespace SistemaGestionDeNomina
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========== Sistema de Gestion de Nomina por Empleados ==========\n");
            
            //Creando un empleado de tipo Asalariado
            EmpleadoAsalariado joseBonilla = new EmpleadoAsalariado("Jose", "Bonilla", "j.bonillaz@correo.com", "Soporte", 450);

            joseBonilla.CalcularPago();
            joseBonilla.MostrarInformacion();

            //Creando un empleado de tipo Empleado por hora
            EmpleadoPorHora peterParker = new EmpleadoPorHora();
            peterParker._Nombre = "Peter";
            peterParker._Apellido = "Parker";
            peterParker._Correo = "p.parker@correo.com";
            peterParker._Departamento= "Servicio al Cliente";
            peterParker._HorasTrabajadas= 38;

            peterParker.CalcularPago();
            peterParker.MostrarInformacion();

            //Creando un empleado de tipo Empleado por comision
            EmpleadoPorComisionNormal clarkKen = new EmpleadoPorComisionNormal();
            clarkKen._Nombre = "Clark";
            clarkKen._Apellido = "Ken";
            clarkKen._Correo = "c.ken@correo.com";
            clarkKen._Departamento = "Ventas";
            clarkKen._VentasTotales = 15535;

            clarkKen.CalcularPago();
            clarkKen.MostrarInformacion();

            //Creando un empleado de tipo Asalariado con Comision
            EmpleadoAsalariadoConComision bruceBanner = new EmpleadoAsalariadoConComision();
            bruceBanner._Nombre = "Bruce";
            bruceBanner._Apellido = "Banner";
            bruceBanner._Correo = "b.banner@correo.com";
            bruceBanner._Departamento = "Negocios";
            bruceBanner._Sueldo = 350;
            bruceBanner._VentasTotales= 14375;

            bruceBanner.CalcularPago();
            bruceBanner.MostrarInformacion();

        }
    }
}
