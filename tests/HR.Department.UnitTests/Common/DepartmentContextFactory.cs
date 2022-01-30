using System;
using System.Collections.Generic;
using System.Linq;
using HR.Department.Core.Entities;
using HR.Department.Core.Entities.ValueObjects;
using HR.Department.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HR.Department.UnitTests.Common
{
    public class DepartmentContextFactory
    {
        public static DepartmentContext Create()
        {
            var options = new DbContextOptionsBuilder<DepartmentContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            var context = new DepartmentContext(options);
            context.Database.EnsureCreated();

            context.Types.AddRange(GetPreconfiguredTypes());
            context.SaveChanges();

            context.Positions.AddRange(GetPreconfiguredPositions(context));
            context.Employees.AddRange(GetPreconfiguredEmployees());
            context.SaveChanges();

            context.PositionEmployees.AddRange(GetPreconfiguredPositionEmployees(context));
            context.SaveChanges();
            return context;
        }

        static IEnumerable<TypePosition> GetPreconfiguredTypes()
        {
            return new List<TypePosition>
            {
                new("Developer"),
                new("Not Developer")
            };
        }

        static IEnumerable<Core.Entities.Position> GetPreconfiguredPositions(DepartmentContext dbContext)
        {

            return new List<Core.Entities.Position>
            {
                new(".NET Developer", dbContext.Types.FirstOrDefault().Id),
                new("Java Developer", dbContext.Types.FirstOrDefault().Id)
            };
        }

        static IEnumerable<Core.Entities.Employee> GetPreconfiguredEmployees()
        {
            return new List<Core.Entities.Employee>
            {
                new("Denis", "Aleksandrov", new Address("Knorina", "Minsk", "Belarus"), "+375292436302", 21, 600),
                new("Marta", "Tishuk", new Address("Lenina", "Minsk", "Belarus"), "+375292436306", 24, 650),
                new("Dima", "Dubok", new Address("Kolasa", "Minsk", "Belarus"), "+375292436301", 31, 700)
            };
        }

        static IEnumerable<PositionEmployee> GetPreconfiguredPositionEmployees(DepartmentContext dbContext)
        {
            return new List<PositionEmployee>
            {
                new PositionEmployee()
                {
                    EmployeeId = dbContext.Employees.FirstOrDefault().Id,
                    PositionId = dbContext.Positions.FirstOrDefault().Id
                }
            };
        }

        public static void Destroy(DepartmentContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
