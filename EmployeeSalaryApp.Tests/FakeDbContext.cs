namespace EmployeeSalaryApp.Tests
{
    using Microsoft.EntityFrameworkCore;

    using EmployeeSalaryApp.Data;

    public class FakeDbContext
    {
        public FakeDbContext()
        {
            var options = new DbContextOptionsBuilder<CustomWebApplicationFactory>()
                .UseInMemoryDatabase(databaseName: "FakeEmployeeDB")
                .Options;

            this.Data = new CustomWebApplicationFactory(options);
        }

        public CustomWebApplicationFactory Data { get; }
    }
}
