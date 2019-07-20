using System;

namespace Payroll.Domain
{
    public class SalariedEmployee : Employee
    {
        private decimal _weeklySalary;

        public decimal WeeklySalary
        {
            get => _weeklySalary;
            set
            {
                if (value >= 0)
                    _weeklySalary = value;
                else throw new ArgumentOutOfRangeException(nameof(WeeklySalary));
            }
        }
        
        public SalariedEmployee(string name, string socialSecurityNumber, decimal weeklySalary)
            : base(name, socialSecurityNumber)
        {
            WeeklySalary = weeklySalary;
        }

        public override decimal Earnings() => WeeklySalary;

        public override string ToString() => $"Salaried Employee: {base.ToString()}\nWeekly Salary: {WeeklySalary}";
    }
}