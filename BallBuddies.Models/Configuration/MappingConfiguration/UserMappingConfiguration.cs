using AutoMapper;
using BallBuddies.Models.Dtos;
using BallBuddies.Models.Entities;

namespace BallBuddies.Models.Configuration.MappingConfiguration
{
    public class UserMappingConfiguration : Profile
    {
        public UserMappingConfiguration()
        {
            CreateMap<UserRegistrationDto, User>();
            CreateMap<User, UserRegistrationDto>();
        }
    }
}
