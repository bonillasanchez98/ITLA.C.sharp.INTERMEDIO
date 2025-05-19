namespace DRY.Entities
{
    public sealed class EmployeeForFullTime : PayRollBase
    {

        public decimal CalculateSalaryForFullTime(decimal baseSalary)
        {
            return CalculateNetSalary(baseSalary);
        }
    }
}
