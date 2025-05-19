namespace DRY
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Ejercicio 2: Aplicando DRY (Don't Repeat Yourself).
             * Una empresa necesita calcular el salario de sus empleados de manera eficiente. Actualmente, hay 
             * código duplicado en los cálculos de impuestos y bonificaciones para empleados de tiempo completo y medio tiempo.
             */

            Console.WriteLine("********** Ejercicio 2: Aplicando DRY (Don't Repeat Yourself) **********");
            Payroll payroll = new Payroll();
            payroll.Menu();
        }
    }
}
