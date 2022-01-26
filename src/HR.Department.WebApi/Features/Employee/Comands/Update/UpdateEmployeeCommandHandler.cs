﻿using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HR.Department.Core.Entities.ValueObjects;
using HR.Department.Core.Interfaces;
using MediatR;

namespace HR.Department.WebApi.Features.Employee.Comands.Update
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
    {
        private readonly IRepository<Core.Entities.Employee> _repository;
        private readonly IMapper _mapper;

        public UpdateEmployeeCommandHandler(
            IRepository<Core.Entities.Employee> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _repository.GetByIdAsync(request.Id, cancellationToken);

            employee.UpdateAddress(new Address(request.Street, request.City, request.Country));
            await _repository.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}