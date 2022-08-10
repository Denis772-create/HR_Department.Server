using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using HR.Department.Core.Commands.Position.UpdatePosition;
using HR.Department.Core.Interfaces;

namespace HR.Department.Core.Dto
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
