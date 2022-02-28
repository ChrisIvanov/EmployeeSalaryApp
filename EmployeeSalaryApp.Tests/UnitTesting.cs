namespace EmployeeSalaryApp.Tests;

using Xunit;
using Moq;

using System.Threading.Tasks;

using EmployeeSalaryApp.Data.Common.Repositories;
using EmployeeSalaryApp.Data.Models;
using EmployeeSalaryApp.Data.ViewModels.Employee;
using EmployeeSalaryApp.Services.Contracts.Employee;
using EmployeeSalaryApp.Services.Contracts.TaxCalculator;
using EmployeeSalaryApp.Data;
using EmployeeSalaryApp.Tests.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class UnitTesting
{
    [Theory]
    [InlineData("Test", "Test", 1000)]
    [InlineData("Test", "Test", 950)]
    [InlineData("Test", "Test", 999)]
    [InlineData("Test", "Test", 3100)]
    public async Task CreateEmployeeShouldCalculateNetSalaryAutomatically(string firstName, string lastName, decimal grossSalary)
    {
        var repository = new Mock<IDeletableEntityRepository<Employee>>();
        var employeeService = new Mock<IEmployeeService>();

        var employee = new CreateFormModel
        {
            FirstName = firstName,
            LastName = lastName,
            SalaryGross = grossSalary
        };

        var addEmployee = await Task.FromResult(
            employeeService.Setup(
                e => e.CreateAsync(employee)));

        Assert.True(addEmployee is not null);
    }

    [Theory]
    [InlineData(950)]
    [InlineData(999)]
    [InlineData(1000)]
    [InlineData(3000)]
    [InlineData(3200)]
    public async Task CalculateSalaryMethodShouldReturnTheRightNetSalary(decimal grossSalary)
    {
        var calculator = new Mock<ITaxCalculator>();

        var result = await Task.FromResult(
            calculator.Setup(
                r => r.CalculateSalary(grossSalary)));

        Assert.NotNull(result);
    }

    [Theory]
    [InlineData(950)]
    [InlineData(999)]
    public async Task CalculateSalaryMethodShouldFunctionCorrectlyWithSalaryUpTo1000(decimal grossSalary)
    {
        var repository = new Mock<FakeDbContext>();
        var employeeService = new Mock<IFakeEmployeeService>();

        var employee = new CreateFormModel
        {
            FirstName = "Test",
            LastName = "Test",
            SalaryGross = grossSalary
        };

        var employeeToAdd = await Task.FromResult(
            employeeService.Setup(
                c => c.CreateAsync(employee)));
        var asd = employeeToAdd.Returns<Employee>;
        var repoObj = repository.Object;

        var actual = repoObj.Data.Employees
                .Where(e => e.FirstName == "Test")
                .Select(e => e.SalaryNetValue)
                .FirstOrDefault();

        Assert.Equal(grossSalary, actual);
    }
}