using System;
using AutoMapper;
using HR.Department.Core.Entities;
using HR.Department.Core.Interfaces;

namespace HR.Department.Core.Dto
{
    public class TypePositionDto : IMapWith<TypePosition>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public void Mapping(Profile profile)=>
            profile.CreateMap<TypePosition, TypePositionDto>();
    }
}
