using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using HR.Department.WebApi.Features.Position.Comands.UpdatePosition;
using HR.Department.WebApi.Mappings;

namespace HR.Department.WebApi.Modes
{
    public class PositionForUpdateDto : IMapWith<UpdatePositionCommand>
    {
        [Required]
        public Guid Id { get; set; }
        public string Name { get; set; }
        [MaxLength(30)]
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PositionForUpdateDto, UpdatePositionCommand>();
        }

    }
}
