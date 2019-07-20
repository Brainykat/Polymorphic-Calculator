using Payroll.Domain;
using System;
using Xunit;

namespace Payroll.UnitTests
{
    public class EmployeeSpec
    {
        [Fact]
        public void ShouldCreateEmployeeWithFullName()
        {
            var name = "John Smith";
            var sut = new SalariedEmployee(name, "111-11-1111", 5000m);

            Assert.Equal(name, sut.Name);
        }

        [Fact]
        public void ShouldCreateEmployeeWithSSN()
        {
            var ssn = "111-11-1111";
            var sut = new SalariedEmployee("John Smith", ssn, 5000m);

            Assert.Equal(ssn, sut.SocialSecurityNumber);
        }

        [Theory]
        [InlineData("", "111-11-1111", 5000)]
        [InlineData(" ", "111-11-1111", 5000)]
        [InlineData(null, "111-11-1111", 5000)]
        public void ShouldThrowArgumentNullExceptionGivenFullNameIsInvalid(string name, string ssn, decimal salary)
        {
            // Approach 1
            Action sut = () => new SalariedEmployee(name, ssn, salary);
            Assert.Throws<ArgumentNullException>(sut);

            // Approach 2
            var exception = Record.Exception(() => new SalariedEmployee(name, ssn, salary));
            Assert.NotNull(exception);
            Assert.IsType<ArgumentNullException>(exception);
        }
        
        [Theory]
        [InlineData("John Smith", "", 5000)]
        [InlineData("John Smith", " ", 5000)]
        [InlineData("John Smith", null, 5000)]
        public void ShouldThrowArgumentNullExceptionGivenSSNIsInvalid(string name, string ssn, decimal salary)
        {
            Action sut = () => new SalariedEmployee(name, ssn, salary);
            var exception = Assert.Throws<ArgumentNullException>(sut);

            // Test for exception message
            //const string message = "SSN is required";
            //Assert.Equal(message, exception.Message);
        }

        [Fact]
        public void ShouldThrowArgumentOutOfRangeExceptionGivenSalaryIsInvalid()
        {
            Action sut = () => new SalariedEmployee("John Smith", "111-11-1111", -1);

            Assert.Throws<ArgumentOutOfRangeException>(sut);
        }


        [Fact]
        public void ShouldReturnTrueGivenSalariedPlusCommissionEmployeeIsFromCommissionEmployee()
        {
            var sut = new SalariedPlusCommissionEmployee("John Smith", "111-11-1111", 50_000m, 0.01, 30_000);

            Assert.IsAssignableFrom<CommissionEmployee>(sut);
        }


        [Fact]
        public void ShouldReturnTrueGivenSalariedPlusCommissionEmployeeIsEmployee()
        {
            var sut = new SalariedPlusCommissionEmployee("John Smith", "111-11-1111", 50_000m, 0.01, 30_000);

            Assert.IsAssignableFrom<Employee>(sut);
        }
    }
}
