namespace DRY.Entities
{
    public abstract class PayRollBase
    {
        private const decimal TAX = 0.18m;
        private const decimal BONUS = 0.05m;

        public virtual decimal CalculateNetSalary(decimal salary)
        {
            decimal tax = salary * TAX;
            decimal bonus = salary * BONUS;

            return salary - tax + bonus;
        }
    }
}
