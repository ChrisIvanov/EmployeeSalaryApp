namespace EmployeeSalaryApp.Services.TaxCalculator
{
    using Microsoft.EntityFrameworkCore;

    using EmployeeSalaryApp.Services.Contracts.TaxCalculator;

    using static EmployeeSalaryApp.Common.GlobalConstants.TaxTypes;
    using EmployeeSalaryApp.Data;

    public class TaxCalculator : ITaxCalculator
    {
        private CustomWebApplicationFactory db;

        public TaxCalculator(CustomWebApplicationFactory db)
        {
            this.db = db;
        }

        public decimal CalculateSalary(decimal salary)
        {
            var netSalary = salary;
            var isSalaryTaxable = IsSalaryTaxable(salary);
            var taxableIncome = salary;

            if (isSalaryTaxable)
            {
                if (salary > 3000)
                {
                    taxableIncome = 3000;
                    netSalary = CalculateTaxes(salary, taxableIncome);
                }
                else
                {
                    taxableIncome = salary;
                    netSalary = CalculateTaxes(salary, taxableIncome);
                }
            }

            return netSalary;
        }

        private decimal CalculateTaxes(decimal salary, decimal taxableIncome)
        {
            var pensionTax = PensionTax(taxableIncome);
            var gimTax = GIMTax(taxableIncome);
            var unimploymentTax = UnimploymentTax(taxableIncome);
            var scpiTax = SCPITax(taxableIncome);
            var healthInsuranceTax = HealthInsuranceTax(taxableIncome);

            var incomeAfterInitialTaxDeduction = CalculateDeductionsOnSocialSecurityIncome(salary, pensionTax, gimTax, unimploymentTax, scpiTax, healthInsuranceTax);

            var incomeTax = ITNPTax(incomeAfterInitialTaxDeduction);

            var netSalary = CalculateTotalTaxDeduction(incomeAfterInitialTaxDeduction, incomeTax);

            return netSalary;
        }

        private decimal CalculateTotalTaxDeduction(decimal incomeAfterInitialTaxDeduction, decimal incomeTax)
        {
            var result = incomeAfterInitialTaxDeduction - incomeTax;

            return result;
        }

        private decimal CalculateDeductionsOnSocialSecurityIncome(decimal salary, decimal pensionTax, decimal gimTax, decimal unimploymentTax, decimal scpiTax, decimal healthInsuranceTax)
        {
            var totalDeduction = salary - pensionTax - gimTax - unimploymentTax - scpiTax - healthInsuranceTax;

            return totalDeduction;
        }

        private decimal ITNPTax(decimal initialTaxDeduction)
        {
            var taxAmount = GetAndCaluclateTax(itnpTax, initialTaxDeduction);

            return taxAmount;
        }


        private decimal HealthInsuranceTax(decimal taxableIncome)
        {
            var taxAmount = GetAndCaluclateTax(healthInsuranceTax, taxableIncome);

            return taxAmount;
        }

        private decimal SCPITax(decimal taxableIncome)
        {
            var taxAmount = GetAndCaluclateTax(scpiTax, taxableIncome);

            return taxAmount;
        }

        private decimal UnimploymentTax(decimal taxableIncome)
        {
            var taxAmount = GetAndCaluclateTax(unimploymentTax, taxableIncome);

            return taxAmount;
        }

        private decimal GIMTax(decimal taxableIncome)
        {
            var taxAmount = GetAndCaluclateTax(gimTax, taxableIncome);

            return taxAmount;
        }

        private decimal PensionTax(decimal taxableIncome)
        {
            var taxAmount = GetAndCaluclateTax(pensionTax, taxableIncome);

            return taxAmount;
        }

        private decimal GetAndCaluclateTax(string taxType, decimal taxableIncome)
        {
            var taxRate = this.db.TaxValues
                .Where(t => t.TaxType == $"{taxType}")
                .Select(t => t.TaxRateInPercentage)
                .FirstOrDefault();

            var result = taxableIncome * (decimal)taxRate / 100;

            return decimal.Round(result, 2);
        }

        public static bool IsSalaryTaxable(decimal amount)
        {
            if (amount < 1000)
            {
                return false;
            }

            return true;
        }
    }
}
