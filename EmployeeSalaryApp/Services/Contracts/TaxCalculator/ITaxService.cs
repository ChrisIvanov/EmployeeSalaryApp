namespace EmployeeSalaryApp.Services.Contracts.TaxCalculator
{
    using EmployeeSalaryApp.Common;
    using EmployeeSalaryApp.Data.ViewModels.Tax;

    public interface ITaxService
    {
        Task<Result> AddAsync(AddFormModel model);

        Task<Result> UpdateAsync(EditFormModel model, int id);

        IEnumerable<GetViewModel> GetAllAsync();

        GetViewModel GetByIdAsync(int id);

        Task<Result> DeleteAsync(int id);
    }
}
