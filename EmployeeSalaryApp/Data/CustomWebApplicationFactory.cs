namespace EmployeeSalaryApp.Data
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.EntityFrameworkCore;

    using EmployeeSalaryApp.Data.Models;

    public class CustomWebApplicationFactory : DbContext
    {
        public CustomWebApplicationFactory(DbContextOptions<CustomWebApplicationFactory> options) 
            : base(options)
        {
        }

        public DbSet<Employee>? Employees { get; set; }

        public DbSet<TaxValue>? TaxValues { get; set; }

        protected void OnConfuguring()
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
