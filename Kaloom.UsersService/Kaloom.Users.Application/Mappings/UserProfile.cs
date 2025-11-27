using AutoMapper;
using Kaloom.Users.Domain.Models;
using Kaloom.Users.Communication.DTOs.Requests;
using Kaloom.Users.Communication.DTOs.Responses;

namespace Kaloom.Users.Application.Mappings
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
