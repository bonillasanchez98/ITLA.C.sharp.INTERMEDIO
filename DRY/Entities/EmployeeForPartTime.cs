namespace DRY.Entities
{
    public sealed class EmployeeForPartTime : PayRollBase
    {
        public decimal CalculateSalarayForPartTime(decimal hourlyRate, int hoursWorked)
        {
            decimal baseSalary = hourlyRate * hoursWorked;
            return CalculateNetSalary(baseSalary);
        }
    }
}
