using ApplicationShared.Dto.NotificationDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Core.Entities;

namespace TaskManagementSystem.Application.IApplicationServices
{
    public interface INotificationAppService
    {

        Task<NotificationDto> GetNotification(int id);
        Task<List<NotificationDto>> GetAllNotification();
        Task CreateNotification(Notification input);
        Task UpdateNotification(Notification input);
        Task DeleteNotification(int id);
    }
}
