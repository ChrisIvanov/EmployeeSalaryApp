namespace EmployeeSalaryApp.Data.ViewModels.Employee
{
    using EmployeeSalaryApp.Data.Models;

    public class GetViewModel
    {
        public string? Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Position { get; set; }

        public decimal SalaryGross { get; set; }

        public decimal SalaryNet { get; set; }
    }
}
