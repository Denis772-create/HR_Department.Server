using Bogus;
using HR.Department.Core.Entities.ValueObjects;

namespace HR.Department.UnitTests.Domain.FakeData
{
    public class EmployeeFakeData
    {
        public EmployeeFakeData(int seed)
        {
            Valid = Valid.UseSeed(seed);
        }

        public Faker<Core.Entities.Employee> Valid { get; }
            = new Faker<Core.Entities.Employee>()
                .CustomInstantiator(f => new Core.Entities.Employee(
                    f.Name.FirstName(),
                    f.Name.LastName(),
                    new Address(
                        f.Address.StreetAddress(),
                        f.Address.City(),
                        f.Address.Country()),
                    f.Phone.PhoneNumber(),
                    f.Random.UShort(10, 70),
                    f.Random.Decimal(0, 700)));
    }
}
