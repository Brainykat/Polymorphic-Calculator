using System;

namespace Payroll.Domain
{
    public class CommissionEmployee : Employee
    {
        private decimal _sales;

        private decimal Sales
        {
            get => _sales;
            set
            {
                if (value >= 0)
                    _sales = value;
                else throw new ArgumentOutOfRangeException(nameof(Sales));
            }
        }

        private double _commissionRate;

        private double CommissionRate
        {
            get => _commissionRate;
            set
            {
                if (value > 0 && value < 1)
                    _commissionRate = value;
                else throw new ArgumentOutOfRangeException(nameof(CommissionRate));
            }
        }

        public CommissionEmployee(string name, string socialSecurityNumber, decimal sales, double commissionRate)
            : base(name, socialSecurityNumber)
        {
            Sales = sales;
            CommissionRate = commissionRate;
        }

        public override decimal Earnings() => Sales * (decimal)CommissionRate;

        public override string ToString() => $"Commission Employee: {base.ToString()}\nTotal Sales: {Sales}\nCommission Rate: {CommissionRate}";
    }
}