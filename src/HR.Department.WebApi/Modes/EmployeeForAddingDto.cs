using System;
using AutoMapper;
using HR.Department.Core.Entities;
using HR.Department.WebApi.Features.Position.Comands.AddEmployee;
using HR.Department.WebApi.Mappings;

namespace HR.Department.WebApi.Modes
{
    public class EmployeeForAddingDto : IMapWith<Employee>
    {
        public Guid PositionId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public decimal RequiredSalary { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<EmployeeForAddingDto, AddEmployeeToPositionCommand>();
        }
    }
}
