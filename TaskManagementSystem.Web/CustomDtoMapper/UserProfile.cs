using ApplicationShared.Dto.NotificationDto;
using ApplicationShared.Dto.UserDto;
using AutoMapper;
using TaskManagementSystem.Core.Entities;

namespace TaskManagementSystem.Web.CustomDtoMapper
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<CreateUserInput, User>().ReverseMap();
            CreateMap<UpdateUserInput, User>().ReverseMap();
        }
    }
}
