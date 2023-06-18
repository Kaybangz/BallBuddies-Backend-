using AutoMapper;
using BallBuddies.Models.Dtos.Request;
using BallBuddies.Models.Dtos.Response;
using BallBuddies.Models.Entities;

namespace BallBuddies.Models.Configuration.MappingConfiguration
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<User, UserRegistrationDto>().ReverseMap();
            CreateMap<Event, EventRequestDto>().ReverseMap();
            CreateMap<Event, EventResponseDto>().ReverseMap();
        }
    }
}
