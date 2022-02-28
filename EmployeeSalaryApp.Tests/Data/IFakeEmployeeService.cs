namespace EmployeeSalaryApp.Tests.Data
{
    using EmployeeSalaryApp.Data.Models;
    using EmployeeSalaryApp.Data.ViewModels.Employee;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IFakeEmployeeService
    {
        Employee CreateAsync(CreateFormModel model);
    }
}
