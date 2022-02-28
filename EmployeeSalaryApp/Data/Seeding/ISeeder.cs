namespace EmployeeSalaryApp.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    public interface ISeeder
    {
        Task SeedAsync(CustomWebApplicationFactory dbContext, IServiceProvider serviceProvider);
    }
}
