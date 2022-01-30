using AutoMapper;
using HR.Department.Core.Entities;
using HR.Department.Core.Entities.ValueObjects;
using HR.Department.WebApi.Mappings;

namespace HR.Department.WebApi.Modes
{
    public class AddressDto : IMapWith<Address>
    {
        public string Street { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Address, AddressDto>().ReverseMap();
        }

    }
}
