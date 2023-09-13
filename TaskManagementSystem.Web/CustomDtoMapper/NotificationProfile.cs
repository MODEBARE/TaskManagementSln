using ApplicationShared.Dto.NotificationDto;
using ApplicationShared.Dto.TaskDto;
using ApplicationSharedDto.TaskDto;
using AutoMapper;
using TaskManagementSystem.Core.Entities;

namespace TaskManagementSystem.Web.CustomDtoMapper
{
    public class NotificationProfile:Profile
    {
        public NotificationProfile()
        {
            CreateMap<Notification, NotificationDto>().ReverseMap(); 
            CreateMap<CreateNotificationInput, Notification>().ReverseMap(); 
            CreateMap<UpdateNotificationInput, Notification>().ReverseMap(); 
        }
    }
}
