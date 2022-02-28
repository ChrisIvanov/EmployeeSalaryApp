namespace EmployeeSalaryApp.Data.ViewModels.Tax
{
    using System.ComponentModel.DataAnnotations;

    public class AddFormModel
    {
        [Required]
        public string? TaxType { get; set; }

        [Required]
        public double TaxRate { get; set; }
    }
}
