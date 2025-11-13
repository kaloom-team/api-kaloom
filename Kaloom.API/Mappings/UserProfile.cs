using AutoMapper;
using Kaloom.API.Models;
using Kaloom.Communication.DTOs.Requests;
using Kaloom.Communication.DTOs.Responses;

namespace Kaloom.API.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserRequest, Usuario>()
                .ReverseMap();

            CreateMap<Usuario, UserResponse>();
        }
    }
}
