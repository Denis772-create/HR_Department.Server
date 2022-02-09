using System;
using FluentValidation;

namespace HR.Department.Core.Queries.Employee.GetEmployeeListByIdPosition
{
    public class GetEmployeeListByIdPositionQueryValidator : AbstractValidator<GetEmployeeListByIdPositionQuery>
    {
        public GetEmployeeListByIdPositionQueryValidator()
        {
            RuleFor(query => query.PositionId).NotEqual(Guid.Empty);
        }
    }
}
