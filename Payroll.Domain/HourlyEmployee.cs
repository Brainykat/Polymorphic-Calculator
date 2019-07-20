using System;

namespace Payroll.Domain
{
    public sealed class HourlyEmployee : Employee
    {
        private decimal _hourlyWage;

        private decimal HourlyWage
    {
            get => _hourlyWage;
            set
            {
                if (value >= 0)
                    _hourlyWage = value;
                else throw new ArgumentOutOfRangeException(nameof(HourlyWage));
            }
        }

        private double _numberOfHoursWorked;

        private double NumberOfHoursWorked
{
            get => _numberOfHoursWorked;
            set
            {
                if (value >= 0)
                    _numberOfHoursWorked = value;
                else throw new ArgumentOutOfRangeException(nameof(NumberOfHoursWorked));
            }
        }

        public HourlyEmployee(string name, string socialSecurityNumber, decimal hourlyWage, double numberOfHoursWorked)
            : base(name, socialSecurityNumber)
        {
            HourlyWage = hourlyWage;
            NumberOfHoursWorked = numberOfHoursWorked;
        }

        public override decimal Earnings()
        {
            if (NumberOfHoursWorked <= 40)
                return HourlyWage * (decimal)NumberOfHoursWorked;
            return HourlyWage * 40 + HourlyWage * (decimal)(NumberOfHoursWorked - 40) * 1.5M;
        }

        public override string ToString() => $"Hourly Employee: {base.ToString()}\nHourly Wage: {HourlyWage}\nHours Worked: {NumberOfHoursWorked}";
    }
}