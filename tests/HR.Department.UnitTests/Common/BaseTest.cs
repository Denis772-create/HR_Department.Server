using System;
using AutoMapper;
using Bogus;
using HR.Department.Infrastructure.Data;
using HR.Department.UnitTests.Domain.FakeData;
using HR.Department.WebApi;
using HR.Department.WebApi.Mappings;

namespace HR.Department.UnitTests.Common
{
    public class BaseTest
    {
        const int seed = 1234;
        protected readonly DepartmentContext Context;
        protected readonly IMapper Mapper;
        protected static Faker Faker { get; private set; }
        protected EmployeeFakeData FakeEmployee { get; private set; }
        public BaseTest()
        {
            Randomizer.Seed = new Random(seed);
            Faker = new Faker();

            Context = DepartmentContextFactory.Create();
            DepartmentContextFactory.SetFakeMembers(Context);
            FakeEmployee = new EmployeeFakeData(seed);

            Mapper = CreateMapper();
        }

        private IMapper CreateMapper()
        {
            var configurationProvider = new MapperConfiguration(cf =>
                cf.AddProfile(new AssemblyMappingProfile(typeof(Startup).Assembly)));

            return configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            DepartmentContextFactory.Destroy(Context);
        }
    }
}
