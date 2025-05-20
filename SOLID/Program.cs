using SOLID.service;

namespace SOLID
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*\Ejercicio 4: Aplicando SOLID
             * Una empresa necesita un sistema de notificaciones que pueda enviar correos electrónicos y SMS, 
             *pero la clase actual viola el Principio de Responsabilidad Única (SRP) porque también maneja el
             *registro de logs*/
            NotificationServiceImpl notificationService = new NotificationServiceImpl();
            Console.WriteLine("********** Ejercicio 4: Aplicando SOLID **********");

            Console.WriteLine("Seleccione el tipo de notificacion:\n" +
                               "1. Email\n" +
                               "2. SMS\n");
            string message;

            int option = int.Parse(Console.ReadLine());
            if (option == 1)
            {
                Console.WriteLine("Ingrese su email: ");
                string email = Console.ReadLine();
                
                Console.WriteLine("Ingrese el mensaje: ");
                message = Console.ReadLine();
                notificationService.SendEmmail(email, message);
            } else if (option == 2)
            {
                Console.WriteLine("Ingrese su telefono con guiones: ");
                string phoneNumber = Console.ReadLine();
                
                Console.WriteLine("Ingrese el mensaje: ");
                message= Console.ReadLine();
                notificationService.SendSMS(phoneNumber, message);
            }else
            {
                Console.WriteLine("Opcion incorrecta!");
            }
        }
    }
}
