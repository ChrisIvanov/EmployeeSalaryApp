using Microsoft.EntityFrameworkCore;

using System.Reflection;

using EmployeeSalaryApp.Data;
using EmployeeSalaryApp.Services.Contracts.TaxCalculator;
using EmployeeSalaryApp.Services.TaxCalculator;
using EmployeeSalaryApp.Services.Contracts.Employee;
using EmployeeSalaryApp.Services.Employee;
using EmployeeSalaryApp.Data.Seeding;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.
builder.Services.AddDbContext<CustomWebApplicationFactory>(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddTransient<ITaxCalculator, TaxCalculator>();
builder.Services.AddTransient<ITaxService, TaxService>();
builder.Services.AddTransient<IEmployeeService, EmployeeService>();

var app = builder.Build();

using (var serviceScope = app.Services.CreateScope())
{
    var dbContext = serviceScope.ServiceProvider.GetRequiredService<CustomWebApplicationFactory>();
    dbContext.Database.Migrate();
    new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
