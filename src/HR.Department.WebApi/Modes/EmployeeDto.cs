using AutoMapper;
using HR.Department.Core.Entities;
using HR.Department.WebApi.Mappings;

namespace HR.Department.WebApi.Modes
{
    public class EmployeeDto : IMapWith<Employee>
    {
        public string FirstName { get; private set; }
        public string Surname { get; private set; }
        public string Phone { get; private set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Employee, EmployeeDto>();
        }
    }
}
