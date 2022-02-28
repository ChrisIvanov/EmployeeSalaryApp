namespace EmployeeSalaryApp.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using AutoMapper;
    using EmployeeSalaryApp.Data.Common.Models;
    using EmployeeSalaryApp.Data.ViewModels.Employee;

    public class Employee : BaseDeletableModel<string>
    {
        public Employee()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        public string? Position { get; set; }

        [Required]
        [Display(Name = "Gross Salary")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal SalaryGrossValue { get; set; }

        [Display(Name = "Net Salary")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal SalaryNetValue { get; set; }
    }
}
