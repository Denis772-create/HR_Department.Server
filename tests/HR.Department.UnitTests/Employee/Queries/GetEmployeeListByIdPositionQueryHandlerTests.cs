using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.Specification;
using FluentAssertions;
using HR.Department.Core.Dto;
using HR.Department.Core.Interfaces;
using HR.Department.Core.Queries.Employee.GetEmployeeListByIdPosition;
using HR.Department.Core.Specifications;
using HR.Department.UnitTests.Common;
using NSubstitute;
using Xunit;

namespace HR.Department.UnitTests.Employee.Queries
{
    public class GetEmployeeListByIdPositionQueryHandlerTests : BaseTest
    {
        [Fact]
        public async Task GetEmployeeListByIdPositionQueryHandler_Success()
        {
            // Arrange
            var lisEmployees = Context.Employees
                .Where(e => e.Positions
                    .Select(p => p.Id)
                    .Contains(DepartmentContextFactory.PositionAId))
                .ToList();
            var repository = Substitute.For<IRepository<Core.Entities.Employee>>();
            repository.ListAsync(specification: default).ReturnsForAnyArgs(Task.FromResult(lisEmployees));

            var handler = new GetEmployeeListByIdPositionQueryHandler(repository, Mapper);

            //Act
            var result = await handler.Handle(
                new GetEmployeeListByIdPositionQuery
                {
                    PositionId = DepartmentContextFactory.PositionAId
                }, CancellationToken.None);

            //Assert
            result.EmployeeList.Count.Should().Be(1);
            result.Should().BeOfType(typeof(EmployeeListDto));

        }
    }
}
