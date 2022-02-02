using System;
using AutoMapper;
using HR.Department.Core.Entities;
using HR.Department.WebApi.Features.Position.Comands.CreatePosition;
using HR.Department.WebApi.Mappings;

namespace HR.Department.WebApi.Modes
{
    public class PositionDto : IMapWith<Position>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid TypePositionId { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Position, PositionDto>();
            profile.CreateMap<PositionDto, CreatePositionCommand>();
        }
    }
}
