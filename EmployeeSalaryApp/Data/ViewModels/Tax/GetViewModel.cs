namespace EmployeeSalaryApp.Data.ViewModels.Tax
{
    using EmployeeSalaryApp.Data.Models;

    public class GetViewModel
    {
        public int Id { get; set; }

        public string? TaxType { get; set; }

        public double TaxRate { get; set; }
    }
}
