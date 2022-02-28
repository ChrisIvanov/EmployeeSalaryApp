namespace EmployeeSalaryApp.Tests.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using EmployeeSalaryApp.Common;
    using EmployeeSalaryApp.Data.Models;
    using EmployeeSalaryApp.Data.ViewModels.Employee;
    using EmployeeSalaryApp.Services.Contracts.Employee;
    using EmployeeSalaryApp.Services.Contracts.TaxCalculator;
    using EmployeeSalaryApp.Data;
    using System.Collections.Generic;

    public class FakeEmployeeService : IFakeEmployeeService
    {
        private readonly FakeDbContext db;
        private readonly ITaxCalculator? taxCalculator;

        public FakeEmployeeService(FakeDbContext db, ITaxCalculator? taxCalculator)
        {
            this.db = db;
            this.taxCalculator = taxCalculator;
        }

        public Employee CreateAsync(CreateFormModel model)
        {
            var employee = new Employee
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Position = model.Position,
                SalaryGrossValue = model.SalaryGross
            };

            var grossSalary = employee.SalaryGrossValue;

            var netSalary = this.taxCalculator.CalculateSalary(grossSalary);

            employee.SalaryNetValue = netSalary;

            this.db.Data.AddAsync(employee);
            this.db.Data.SaveChangesAsync();

            return employee;
        }

        //public async Task<Result> AddRangeAsync(List<CreateFormModel> models)
        //{
        //    foreach (var model in models)
        //    {
        //        var employee = new Employee
        //        {
        //            FirstName = model.FirstName,
        //            LastName = model.LastName,
        //            Position = model.Position,
        //            SalaryGrossValue = model.SalaryGross
        //        };

        //        var grossSalary = employee.SalaryGrossValue;

        //        var netSalary = this.taxCalculator.CalculateSalary(grossSalary);

        //        employee.SalaryNetValue = netSalary;

        //        await this.db.Employees.AddAsync(employee);
        //    }

        //    await this.db.SaveChangesAsync();

        //    return true;
        //}

        //public async Task<Result> UpdateAsync(UpdateFormModel model, string employeeId)
        //{
        //    var employee = await this.db.Employees
        //        .Where(e => e.Id == employeeId)
        //        .FirstOrDefaultAsync();

        //    employee.FirstName = model.FirstName;
        //    employee.LastName = model.LastName;
        //    employee.SalaryGrossValue = model.SalaryGross;

        //    return true;
        //}

        //public IEnumerable<GetViewModel> GetAllAsync()
        //{
        //    var employeeList = this.db.Employees.ToList();

        //    var employeesViewModelList = new List<GetViewModel>();

        //    foreach (var employee in employeeList)
        //    {
        //        var employeeViewModel = new GetViewModel
        //        {
        //            Id = employee.Id,
        //            FirstName = employee.FirstName,
        //            LastName = employee.LastName,
        //            Position = employee.Position,
        //            SalaryGross = employee.SalaryGrossValue,
        //            SalaryNet = employee.SalaryNetValue
        //        };

        //        employeesViewModelList.Add(employeeViewModel);
        //    }

        //    return employeesViewModelList;
        //}

        //public async Task<GetViewModel> GetByIdAsync(string id)
        //{
        //    var employee = await this.db.Employees
        //        .Where(e => e.Id == id)
        //        .FirstOrDefaultAsync();

        //    if (employee == null)
        //    {
        //        return null;
        //    }

        //    var employeeViewModel = new GetViewModel
        //    {
        //        FirstName = employee.FirstName,
        //        LastName = employee.LastName,
        //        Position = employee.Position,
        //        SalaryGross = employee.SalaryGrossValue,
        //        SalaryNet = employee.SalaryNetValue
        //    };

        //    return employeeViewModel;
        //}

        //public async Task<Result> DeleteAsync(string id)
        //{
        //    var employee = await this.db.Employees
        //        .Where(e => e.Id == id)
        //        .FirstOrDefaultAsync();

        //    if (employee == null)
        //    {
        //        return false;
        //    }

        //    employee.IsDeleted = true;

        //    this.db.Employees.Remove(employee);
        //    await this.db.SaveChangesAsync();

        //    return true;
        //}
    }
}
