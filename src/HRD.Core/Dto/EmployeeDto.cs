using System;
using AutoMapper;
using HR.Department.Core.Entities;
using HR.Department.Core.Interfaces;

namespace HR.Department.Core.Dto
{
    public class EmployeeDto : IMapWith<Employee>
    {
        public Guid Id { get; set; }
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
            profile.CreateMap<Employee, EmployeeDto>()
                .ForMember(dto => dto.Country,
                    config =>
                        config.MapFrom(r => r.Address.Country))
                .ForMember(dto => dto.City,
                    config =>
                        config.MapFrom(r => r.Address.City))
                .ForMember(dto => dto.Street,
                    config =>
                        config.MapFrom(r => r.Address.Street));

            profile.CreateMap<EmployeeDto, Employee>()
                //.ForMember(dto => dto.Address.Country,
                //    config =>
                //        config.MapFrom(r => r.Country))
                //.ForMember(dto => dto.Address.City,
                //    config =>
                //        config.MapFrom(r => r.City))
                //.ForMember(dto => dto.Address.Street,
                //    config =>
                //        config.MapFrom(r => r.Street))
                .ForMember(dto => dto.FirstName,
                config =>
                    config.MapFrom(r => r.FirstName));



        }
    }
}
