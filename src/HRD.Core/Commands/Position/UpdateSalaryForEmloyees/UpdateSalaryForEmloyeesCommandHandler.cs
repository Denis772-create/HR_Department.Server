using System.Threading;
using System.Threading.Tasks;
using HR.Department.Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HR.Department.Core.Commands.Position.UpdateSalaryForEmloyees
{
    public class UpdateSalaryForEmloyeesCommandHandler : IRequestHandler<UpdateSalaryForEmloyeesCommand, int>
    {
        private readonly IRepository<Core.Entities.Employee> _repository;

        public UpdateSalaryForEmloyeesCommandHandler(IRepository<Core.Entities.Employee> repository) =>
            _repository = repository;


        public async Task<int> Handle(UpdateSalaryForEmloyeesCommand request, CancellationToken cancellationToken)
        {

            var positionEmployees = await _repository.PositionEmployees
                .FromSqlRaw("GetSalaryLessThanFiveHundred")
                .ToListAsync(cancellationToken);

            foreach (var pe in positionEmployees)
            {
                var employee = await _repository.GetByIdAsync(pe.EmployeeId);
                pe.Salary = employee.RequiredSalary;
            }

            await _repository.SaveChangesAsync(cancellationToken);

            return positionEmployees.Count;
        }
    }
}
