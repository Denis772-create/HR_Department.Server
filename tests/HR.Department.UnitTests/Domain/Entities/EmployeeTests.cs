using System;
using FluentAssertions;
using HR.Department.UnitTests.Common;
using Xunit;
using Address = HR.Department.Core.Entities.ValueObjects.Address;

namespace HR.Department.UnitTests.Domain.Entities
{
    public class EmployeeTests : BaseTest
    {
        [Fact]
        public void Employee_with_invalid_arguments_throw_exceptions()
        {
            Assert.Throws<ArgumentException>(() => new Core.Entities.Employee("", null, null, Faker.Phone.PhoneNumber(), 1, 1m));
            Assert.Throws<ArgumentNullException>(() => new Core.Entities.Employee("Bob", null, null, null, 1, 1m));
            Assert.Throws<ArgumentException>(() => new Core.Entities.Employee("Bob", null, null, Faker.Phone.PhoneNumber(), -1, 1m));
            Assert.Throws<ArgumentException>(() => new Core.Entities.Employee("Bob", null, null, Faker.Phone.PhoneNumber(), -1, 1m));
        }

        [Fact]
        public void Employee_with_valid_arguments_is_created()
        {
            var fName = Faker.Name.FirstName();
            var phone = Faker.Phone.PhoneNumber();
            Func<Core.Entities.Employee> createEmployee = () =>
                new Core.Entities.Employee(
                    fName,
                    null,
                    null,
                    phone,
                    15,
                    500);

            var employee = createEmployee();

            createEmployee.Should().NotThrow();
            employee.FirstName.Should().Be(fName);
            employee.Phone.Should().Be(phone);
            employee.Age.Should().Be(15);
            employee.RequiredSalary.Should().Be(500);
        }

        [Fact]
        public void UpdateAddress_is_Success()
        {
            // Arrange
            var employee = FakeEmployee.Valid.Generate();
            var address = new Address(Faker.Address.Country(), Faker.Address.City(), Faker.Address.StreetAddress());

            // Act
            employee.UpdateAddress(address);

            // Assert 
            Assert.NotNull(employee.Address);
            Assert.Equal(employee.Address, address);
        }

        [Fact]
        public void UpdateAddress_with_null_argument_is_Failure()
        {
            // Arrange
            var employee = FakeEmployee.Valid.Generate();

            // Act
            Action updateResult = () => employee.UpdateAddress(null);

            // Assert 
            updateResult.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void UpdatePhone_is_Success()
        {
            // Arrange
            var employee = FakeEmployee.Valid.Generate();
            var phone = Faker.Phone.PhoneNumber();

            // Act
            employee.UpdatePhone(phone);

            // Assert 
            Assert.NotNull(employee.Phone);
            Assert.Equal(employee.Phone, phone);
        }

        [Fact]
        public void UpdatePhone_with_empty_argument_is_Failure()
        {
            // Arrange
            var employee = FakeEmployee.Valid.Generate();

            // Act
            Action updateResult = () => employee.UpdatePhone("");

            // Assert 
            updateResult.Should().Throw<ArgumentException>();
        }
    }
}
