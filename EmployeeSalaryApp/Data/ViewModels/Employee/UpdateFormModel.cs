namespace EmployeeSalaryApp.Data.ViewModels.Employee
{
    using System.ComponentModel.DataAnnotations;

    public class UpdateFormModel
    {
        [MinLength(3, ErrorMessage = "Name is too short.")]
        [MaxLength(20, ErrorMessage = "Name is too long.")]
        public string? FirstName { get; set; }

        [MinLength(3, ErrorMessage = "Name is too short.")]
        [MaxLength(20, ErrorMessage = "Name is too long.")]
        public string? LastName { get; set; }

        [Range(650, 10000)]
        public decimal SalaryGross { get; set; }
    }
}
