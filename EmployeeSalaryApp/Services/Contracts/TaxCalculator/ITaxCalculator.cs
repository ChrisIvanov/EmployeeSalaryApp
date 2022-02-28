namespace EmployeeSalaryApp.Services.Contracts.TaxCalculator
{
    public interface ITaxCalculator
    {
        decimal CalculateSalary(decimal amount);
    }
}
