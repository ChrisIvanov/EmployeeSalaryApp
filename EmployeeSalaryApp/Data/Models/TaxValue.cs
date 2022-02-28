namespace EmployeeSalaryApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using EmployeeSalaryApp.Data.Common.Models;
    using EmployeeSalaryApp.Data.ViewModels.Tax;

    public class TaxValue : BaseDeletableModel<int>
    {
        [Required]
        [MinLength(3, ErrorMessage = "Name of Tax Type is too short.")]
        [Display(Name = "Tax Type")]
        public string? TaxType { get; set; }

        [Required]
        [Range(0.01, 100.00, ErrorMessage = "Value of tax percentage is not valid.")]
        [Display(Name = "Tax Rate(%)")]
        public double TaxRateInPercentage { get; set; }
    }
}
