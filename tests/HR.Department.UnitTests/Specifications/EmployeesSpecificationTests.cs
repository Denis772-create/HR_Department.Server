using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using HR.Department.Core.Specifications;
using HR.Department.UnitTests.Common;
using NSubstitute;
using Xunit;

namespace HR.Department.UnitTests.Specifications
{
    public class EmployeesSpecificationTests : BaseTest
    {
        private readonly Guid _positionIdA = Guid.NewGuid();

        [Fact]
        public void ReturnOneEmployee()
        {
            var spec = new EmployeesSpecification(_positionIdA);

            var result = spec.Evaluate(GetTestCollection());

            Assert.NotNull(result);
            result.Count().Should().Be(1);
        }


        private List<Core.Entities.Employee> GetTestCollection()
        {
            var listEmployees = new List<Core.Entities.Employee>();

            var positionA = Substitute.For<Core.Entities.Position>();
            positionA.Id.Returns(_positionIdA);

            var positionB = Substitute.For<Core.Entities.Position>();
            positionB.Id.Returns(Guid.NewGuid());

            var employeeA = new Core.Entities.Employee();
            employeeA.AddPosition(positionA);

            var employeeB = new Core.Entities.Employee();
            employeeA.AddPosition(positionB);

            listEmployees.AddRange(new List<Core.Entities.Employee>()
            {
                employeeA, employeeB
            });
            return listEmployees;
        }
    }
}
