namespace EmployeeSalaryApp.Data.Seeding
{
    using EmployeeSalaryApp.Data.Models;
    using EmployeeSalaryApp.Services.TaxCalculator;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Threading.Tasks;

    public class EmployeeSeeder : ISeeder
    {
        public async Task SeedAsync(CustomWebApplicationFactory dbContext, IServiceProvider serviceProvider)
        {
            var employees = await dbContext.Employees.ToListAsync();

            if (employees.Count() == 0)
            {
                var seedEmployees = SeedEmployees();

                foreach (var employee in seedEmployees)
                {
                    if (!employees.Contains(employee))
                    {
                        await dbContext.AddAsync(employee);
                    }
                }
            }
        }

        private List<Employee> SeedEmployees()
        {
            var emplyeeList = new List<Employee>();

            var employeeJohn = new Employee
            {
                FirstName = "John",
                LastName = "Doe",
                Position = ".NET Developer",
                SalaryGrossValue = 2400
            };

            var employeeMary = new Employee
            {
                FirstName = "Mary",
                LastName = "Hopkins",
                Position = ".NET Developer",
                SalaryGrossValue = 1800
            };

            var employeePesho = new Employee
            {
                FirstName = "Pesho",
                LastName = "Peshev",
                Position = "System Administrator",
                SalaryGrossValue = 3500
            };

            var employeeJoe = new Employee
            {
                FirstName = "Joe",
                LastName = "Smileton",
                Position = "Human Resources",
                SalaryGrossValue = 2300
            };

            emplyeeList.Add(employeeJohn);
            emplyeeList.Add(employeeMary);
            emplyeeList.Add(employeePesho);
            emplyeeList.Add(employeeJoe);

            return emplyeeList;
        }
    }
}
