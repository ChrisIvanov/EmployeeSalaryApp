namespace EmployeeSalaryApp.Tests
{
    using EmployeeSalaryApp.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using static EmployeeSalaryApp.Common.GlobalConstants.TaxTypes;

    public class FakeTaxValuesSeeding
    {
        public IEnumerable<TaxValue> FakeTaxValues()
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
