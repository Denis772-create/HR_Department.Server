using System;
using AutoMapper;
using HR.Department.Core.Entities;
using HR.Department.WebApi.Mappings;

namespace HR.Department.WebApi.Modes
{
    public class PositionDto : IMapWith<Position>
    {
        public Guid Id { get; set; }
        public  string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Position, PositionDto>();
        }
    }
}
