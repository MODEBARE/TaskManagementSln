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

        Task<Notification> GetNotification(int id);
        Task<List<Notification>> GetAllNotification();
        Task CreateNotification(Notification input);
        Task UpdateNotification(Notification input);
        Task DeleteNotification(int id);
    }
}
