using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bogus;
using HR.Department.Core.Interfaces;
using HR.Department.UnitTests.Common;
using HR.Department.WebApi.Features.Employee.Comands.Update;
using HR.Department.WebApi.Modes;
using NSubstitute;
using FluentAssertions;
using HR.Department.Core.Exeptions;
using MediatR;
using Xunit;

namespace HR.Department.UnitTests.Employee.Comands
{
    public class UpdateEmployeeCommandHandlerTests : BaseTest
    {
        [Fact]
        public async Task UpdateEmployeeCommandHandler_Success()
        {
            // Arrange
            var address = new AddressDto()
            {
                City = Faker.Address.City(),
                Street = Faker.Address.StreetName(),
                Country = Faker.Address.Country()
            };

            var employee = Context.Employees.FirstOrDefault(e =>
                e.Id == DepartmentContextFactory.EmployeeAId);

            var repository = Substitute.For<IRepository<Core.Entities.Employee>>();
            repository.GetByIdAsync(DepartmentContextFactory.EmployeeAId).Returns(employee);
            repository.SaveChangesAsync().Returns(Task.CompletedTask);

            var handler = new UpdateEmployeeCommandHandler(repository, Mapper);

            // Act
            var result = await handler.Handle(new UpdateEmployeeCommand
            {
                Id = DepartmentContextFactory.EmployeeAId,
                Address = address
            }, CancellationToken.None);

            // Assert
            result.Should().BeOfType(typeof(Unit));

            await repository.Received(1).GetByIdAsync(DepartmentContextFactory.EmployeeAId);
            await repository.Received(1).SaveChangesAsync();
        }

        [Fact]
        public async Task UpdateEmployeeCommandHandler_FailOnWrongId()
        {
            // Arrange
            var employee = Context.Employees.FirstOrDefault(e =>
                e.Id == DepartmentContextFactory.EmployeeAId);

            var repository = Substitute.For<IRepository<Core.Entities.Employee>>();
            repository.GetByIdAsync(DepartmentContextFactory.EmployeeAId).Returns(employee);
            repository.SaveChangesAsync().Returns(Task.CompletedTask);

            var handler = new UpdateEmployeeCommandHandler(repository, Mapper);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(new UpdateEmployeeCommand
                {
                    Id = Guid.NewGuid(),
                    Address = default
                }, CancellationToken.None);
            });
        }

    }
}
