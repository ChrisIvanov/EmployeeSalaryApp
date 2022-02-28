namespace EmployeeSalaryApp.Data.Seeding.TaxSeeding
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    
    using EmployeeSalaryApp.Data.Models;

    using static EmployeeSalaryApp.Common.GlobalConstants.TaxTypes;

    public class TaxSeeder : ISeeder
    {
        public async Task SeedAsync(CustomWebApplicationFactory dbContext, IServiceProvider serviceProvider)
        {
            var taxes = await dbContext.TaxValues.ToListAsync();

            if (taxes.Count() == 0)
            {
                var taxCollection = SeedTaxes();

                foreach (var tax in taxCollection)
                {
                    if (!taxes.Contains(tax))
                    {
                        await dbContext.TaxValues.AddAsync(tax);
                    }
                }
            }
        }

        private IEnumerable<TaxValue> SeedTaxes()
        {
            var taxes = new List<TaxValue>();

            // ДОО (Данък обществено осигуряване)

            //фонд "Пенсии"
            var pension = new TaxValue
            {
                TaxType = pensionTax,
                TaxRateInPercentage = 6.58
            };
            taxes.Add(pension);

            //фонд ОЗМ
            var GIM = new TaxValue
            {
                TaxType = gimTax,
                TaxRateInPercentage = 1.4
            };
            taxes.Add(GIM);

            //фонд "Безработица"
            var unemployment = new TaxValue
            {
                TaxType = unimploymentTax,
                TaxRateInPercentage = 0.4
            };
            taxes.Add(unemployment);

            //фонд "ДЗПО" в УПФ
            var SCPI = new TaxValue
            {
                TaxType = scpiTax,
                TaxRateInPercentage = 2.2
            };
            taxes.Add(SCPI);

            //фонд "Здравно осигуряване"
            var healthInsurance = new TaxValue
            {
                TaxType = healthInsuranceTax,
                TaxRateInPercentage = 3.2
            };
            taxes.Add(healthInsurance);

            //ДДФЛ (Данък върху Дохода на Физически Лица)
            var ITNP = new TaxValue
            {
                TaxType = itnpTax,
                TaxRateInPercentage = 10
            };
            taxes.Add(ITNP);

            return taxes;
        }
    }
}
