namespace EmployeeSalaryApp.Data.ViewModels.Employee
{
    using System.ComponentModel.DataAnnotations;

    public class CreateFormModel
    {
        [Required]
        [MinLength(3, ErrorMessage = "Name is too short.")]
        [MaxLength(20, ErrorMessage = "Name is too long.")]
        public string? FirstName { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Name is too short.")]
        [MaxLength(20, ErrorMessage = "Name is too long.")]
        public string? LastName { get; set; }

        public string? Position { get; set; }

        [Required]
        public decimal SalaryGross { get; set; }
    }
}
