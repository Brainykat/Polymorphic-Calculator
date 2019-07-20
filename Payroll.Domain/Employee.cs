using System;

namespace Payroll.Domain
{
    public abstract class Employee
    {
        private string _name;

        public string Name
        {
            get => _name;
            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _name = value;
                else throw new ArgumentNullException(nameof(_name), "Name is required");
            }
        }


        private string _socialSecurityNumber;

        public string SocialSecurityNumber
        {
            get => _socialSecurityNumber;
            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _socialSecurityNumber = value;
                else throw new ArgumentNullException(nameof(Name), "SSN is required");
            }
        }


        protected Employee(string name, string socialSecurityNumber)
        {
            Name = name;
            SocialSecurityNumber = socialSecurityNumber;
        }

        public abstract decimal Earnings();

        public override string ToString() => $"{Name}\nSSN: {SocialSecurityNumber}";
    }
}
