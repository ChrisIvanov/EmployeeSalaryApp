namespace EmployeeSalaryApp.Services.TaxCalculator
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using EmployeeSalaryApp.Common;
    using EmployeeSalaryApp.Data;
    using EmployeeSalaryApp.Data.Models;
    using EmployeeSalaryApp.Data.ViewModels.Tax;
    using EmployeeSalaryApp.Services.Contracts.TaxCalculator;

    public class TaxService : ITaxService
    {
        private CustomWebApplicationFactory db;

        public TaxService(CustomWebApplicationFactory db)
        {
            this.db = db;
        }

        public async Task<Result> AddAsync(AddFormModel model)
        {
            var taxes = await this.db.TaxValues
                .Where(t => t.TaxType == model.TaxType)
                .FirstOrDefaultAsync();

            if (taxes != null)
            {
                return false;
            }

            var newTax = new TaxValue
            {
                TaxType = model.TaxType,
                TaxRateInPercentage = model.TaxRate
            };

            this.db.TaxValues.AddAsync(newTax);
            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<Result> UpdateAsync(EditFormModel model, int id)
        {
            var tax = await this.db.TaxValues
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync();

            if (tax == null)
            {
                return false;
            }

            tax.TaxType = (model.TaxType == null) ? tax.TaxType : model.TaxType;
            tax.TaxRateInPercentage = (model.TaxRate == 0) ? tax.TaxRateInPercentage : model.TaxRate;

            this.db.TaxValues.Update(tax);
            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<Result> DeleteAsync(int id)
        {
            var tax = await this.db.TaxValues
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync();

            if (tax == null)
            {
                return false;
            }

            this.db.TaxValues.Remove(tax);
            await this.db.SaveChangesAsync();

            return true;
        }

        public IEnumerable<GetViewModel> GetAllAsync()
        {
            var taxes = this.db.TaxValues
                .ToList();

            var taxesViewModelList = new List<GetViewModel>();

            foreach (var tax in taxes)
            {
                var taxViewModel = new GetViewModel
                {
                    Id = tax.Id,
                    TaxType = tax.TaxType,
                    TaxRate = tax.TaxRateInPercentage
                };

                taxesViewModelList.Add(taxViewModel);
            }

            return taxesViewModelList;
        }

        public GetViewModel GetByIdAsync(int id)
        {
            var tax = this.db.TaxValues
                .Where(t => t.Id == id)
                .FirstOrDefault();

            if (tax == null)
            {
                return null;
            }

            var taxViewModel = new GetViewModel
            {
                Id = id,
                TaxType = tax.TaxType,
                TaxRate = tax.TaxRateInPercentage
            };

            return taxViewModel;
        }
    }
}
