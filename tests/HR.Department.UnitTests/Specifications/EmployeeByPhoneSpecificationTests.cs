using System.Collections.Generic;
using System.Linq;
using HR.Department.Core.Specifications;
using HR.Department.UnitTests.Common;
using NSubstitute;
using Xunit;

namespace HR.Department.UnitTests.Specifications
{
    public class EmployeeByPhoneSpecificationTests : BaseTest
    {
        private readonly string _phoneEmployeeA = Faker.Phone.PhoneNumber();

        [Fact]
        public void GetOneEmployeeByPhone_Success()
        {
            var spec = new EmployeeByPhoneSpecification(_phoneEmployeeA);

            var result = spec.Evaluate(GetTestCollection());

            Assert.NotNull(result);
            Assert.Single(result.ToList());
        }


        public List<Core.Entities.Employee> GetTestCollection()
        {
            var emplA = Substitute.For<Core.Entities.Employee>();
            emplA.Phone.Returns(_phoneEmployeeA);

            var emplB = Substitute.For<Core.Entities.Employee>();
            emplB.Phone.Returns(Faker.Phone.PhoneNumber());

            return new List<Core.Entities.Employee>() { emplA, emplB };
        }

    }
}
