using Payroll.Domain;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Payroll.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee salariedEmployee = new SalariedEmployee("John Smith", "111-11-1111", 800);
            Employee hourlyEmployee = new HourlyEmployee("Karen Price", "222-22-2222", 16.75m, 40d);
            Employee commissionEmployee = new CommissionEmployee("Sue Jones", "333-33-3333", 10_000m, 0.06d);
            Employee salariedPlusCommissionEmployee = new SalariedPlusCommissionEmployee("Bob Lewis", "444-44-4444", 5_000, 0.04d, 300);

            SalariedPlusCommissionEmployee salariedPlusCommissionEmployeeWith10PercentReward = (SalariedPlusCommissionEmployee)salariedPlusCommissionEmployee;
            salariedPlusCommissionEmployeeWith10PercentReward.BaseSalary *= 1.1M;


            Console.WriteLine("Employees processed individually:");
            Console.WriteLine("-----------------------------------------------------------------------------------------");

            Console.WriteLine($"{salariedEmployee}\nEarned: {salariedEmployee.Earnings()}");
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Console.WriteLine($"{hourlyEmployee}\nEarned: {hourlyEmployee.Earnings()}");
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Console.WriteLine($"{commissionEmployee}\nEarned: {commissionEmployee.Earnings()}");
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Console.WriteLine($"{salariedPlusCommissionEmployee}\nEarned: {salariedPlusCommissionEmployee.Earnings()}");
            Console.WriteLine("-----------------------------------------------------------------------------------------");


            List<Employee> employees = new List<Employee>
            {
                salariedEmployee, hourlyEmployee, commissionEmployee, salariedPlusCommissionEmployee
            };

            Console.WriteLine("Employees processed polymorphically:");
            Console.WriteLine("-----------------------------------------------------------------------------------------");

            foreach (var employee in employees)
            {
                Console.WriteLine(employee);

                if (employee is SalariedPlusCommissionEmployee salariedPlusCommissionEmployee1)
                {
                    salariedPlusCommissionEmployee1.BaseSalary *= 1.1m;
                    Console.WriteLine($"new base salary with 10% increase is: {salariedPlusCommissionEmployee1.BaseSalary}");
                }

                Console.WriteLine($"Earned {employee.Earnings()}");
                Console.WriteLine("-----------------------------------------------------------------------------------------");
            }

            Console.ReadLine();
        }
    }
}
