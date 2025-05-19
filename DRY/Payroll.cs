using DRY.Entities;

namespace DRY
{
    public sealed class Payroll 
    {
        private EmployeeForFullTime EmployeeForFullTime = new EmployeeForFullTime();
        private EmployeeForPartTime EmployeeForPartTime = new EmployeeForPartTime();
        public void Menu()
        {
            try
            {
                Console.Write("Seleccione el tipo de empleado (1: Tiempo completo, 2: Medio tiempo): ");
                ChooseOption(int.Parse(Console.ReadLine()));
            }catch
            {
                throw new Exception("Error, ingrese 1 o 2 !");
            }
        }

        private void ChooseOption (int option)
        {
            decimal baseSalary;
            switch (option)
            {
                case 1:
                    Console.Write("Ingrese salario base: ");
                    baseSalary = decimal.Parse(Console.ReadLine());
                    EmployeeForFullTime.CalculateNetSalary(baseSalary);
                    Console.WriteLine($"Salario neto después de impuestos y bono: ${baseSalary}");
                    Console.ReadLine();
                    break;
                case 2:
                    Console.Write("Ingrese el sueldo por hora: ");
                    decimal hourlyRate = decimal.Parse(Console.ReadLine());
                    Console.Write("Ingrese las horas trabajadas: ");
                    int hourWorked = int.Parse(Console.ReadLine());
                    baseSalary = EmployeeForPartTime.CalculateSalarayForPartTime(hourlyRate, hourWorked);
                    Console.WriteLine($"Salario neto después de impuestos y bono: ${baseSalary}");
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Ha ocurrido un error, verifique!");
                    Console.ReadLine();
                break;

            }
        }
    }
}
