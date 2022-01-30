using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.Department.Core.Entities;
using HR.Department.Core.Entities.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace HR.Department.Infrastructure.Data
{
    public class DepartmentContextSeed
    {
        private static DepartmentContext _dbContext;
        public static async Task SeedAsync(DepartmentContext departmentContext)
        {
            _dbContext = departmentContext;
            try
            {
                if (departmentContext.Database.IsSqlServer())
                    departmentContext.Database.Migrate();

                if (!await departmentContext.Types.AnyAsync())
                {
                    await departmentContext.Types.AddRangeAsync(
                        GetPreconfiguredTypes());

                    await departmentContext.SaveChangesAsync();
                }

                if (!await departmentContext.Positions.AnyAsync())
                {
                    await departmentContext.Positions.AddRangeAsync(
                        GetPreconfiguredPositions());

                    await departmentContext.SaveChangesAsync();
                }

                if (!await departmentContext.Employees.AnyAsync())
                {
                    await departmentContext.Employees.AddRangeAsync(
                        GetPreconfiguredEmployees());

                    await departmentContext.SaveChangesAsync();
                }

                if (!await departmentContext.PositionEmployees.AnyAsync())
                {
                    await departmentContext.PositionEmployees.AddRangeAsync(
                        GetPreconfiguredPositionEmployees());

                    await departmentContext.SaveChangesAsync();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        static IEnumerable<TypePosition> GetPreconfiguredTypes()
        {
            return new List<TypePosition>
            {
                new("Developer"),
                new("Not Developer")
            };
        }

        static IEnumerable<PositionEmployee> GetPreconfiguredPositionEmployees()
        {
            return new List<PositionEmployee>
            {
                new PositionEmployee()
                {
                    EmployeeId = _dbContext.Employees.FirstOrDefault().Id,
                    PositionId = _dbContext.Positions.FirstOrDefault().Id
                }
            };
        }

        static IEnumerable<Employee> GetPreconfiguredEmployees()
        {
            return new List<Employee>
            {
                new("Denis", "Aleksandrov", new Address("Knorina", "Minsk", "Belarus"), "+375292436302", 21, 600),
                new("Marta", "Tishuk", new Address("Lenina", "Minsk", "Belarus"), "+375292436306", 24, 650),
                new("Dima", "Dubok", new Address("Kolasa", "Minsk", "Belarus"), "+375292436301", 31, 700)
            };
        }

        static IEnumerable<Position> GetPreconfiguredPositions()
        {

            return new List<Position>
            {
                new(".NET Developer", _dbContext.Types.FirstOrDefault().Id),
                new("Java Developer", _dbContext.Types.FirstOrDefault().Id)
            };
        }
    }
}
