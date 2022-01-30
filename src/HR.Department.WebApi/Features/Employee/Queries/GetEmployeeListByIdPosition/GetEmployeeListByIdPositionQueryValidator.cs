using System;
using FluentValidation;

namespace HR.Department.WebApi.Features.Employee.Queries.GetEmployeeListByIdPosition
{
    public class GetEmployeeListByIdPositionQueryValidator : AbstractValidator<GetEmployeeListByIdPositionQuery>
    {
        public GetEmployeeListByIdPositionQueryValidator()
        {
            RuleFor(query => query.PositionId).NotEqual(Guid.Empty);
        }
    }
}
