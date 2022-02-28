namespace EmployeeSalaryApp.Services.Contracts.Employee
{
    using EmployeeSalaryApp.Common;
    using EmployeeSalaryApp.Data.ViewModels.Employee;

    public interface IEmployeeService
    {
        Task<Result> CreateAsync(CreateFormModel model);

        Task<Result> AddRangeAsync(List<CreateFormModel> models);

        Task<Result> UpdateAsync(UpdateFormModel model, string employeeId);

        IEnumerable<GetViewModel> GetAllAsync();

        Task<GetViewModel> GetByIdAsync(string id);

        Task<Result> DeleteAsync(string id);
    }
}
