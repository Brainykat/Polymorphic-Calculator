using System;

namespace Payroll.Domain
{
    public sealed class SalariedPlusCommissionEmployee
        : CommissionEmployee
    {
        private decimal _baseSalary;

        public decimal BaseSalary
        {
            get => _baseSalary;
            set
            {
                if (value >= 0)
                    _baseSalary = value;
                else throw new ArgumentOutOfRangeException(nameof(BaseSalary));
            }
        }

        public SalariedPlusCommissionEmployee(string name, string socialSecurityNumber, decimal sales, double commissionRate, decimal baseSalary)
            : base(name, socialSecurityNumber, sales, commissionRate)
        {
            if(baseSalary < 0) throw new ArgumentOutOfRangeException(nameof(BaseSalary));

            BaseSalary = baseSalary;
        }

        public override decimal Earnings() => base.Earnings() + BaseSalary;

        public override string ToString() => $"Salaried Plus Commission Employee: {base.ToString()}\nBase Salary: {BaseSalary}";
    }
}