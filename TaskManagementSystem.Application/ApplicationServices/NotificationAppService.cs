using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Application.IApplicationServices;
using TaskManagementSystem.Core.Entities;
using TaskManagementSystem.Core.Interfaces;

namespace TaskManagementSystem.Application.ApplicationServices
{
    public class NotificationAppService: INotificationAppService
    {
        private readonly INotificationRepository<Notification, int> _notificationRepository;

        public NotificationAppService(INotificationRepository<Notification, int> notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task<Notification> GetNotification(int id)
        {
            return await _notificationRepository.GetByIdAsync(id);
        }

        public async Task<List<Notification>> GetAllNotification()
        {
            return await _notificationRepository.GetAllAsync();
        }

        public async Task CreateNotification(Notification input)
        {
            await _notificationRepository.CreateAsync(input);
        }

        public async Task UpdateNotification(Notification input)
        {
            await _notificationRepository.UpdateAsync(input);
        }

        public async Task DeleteNotification(int id)
        {
            await _notificationRepository.DeleteAsync(id);
        }



        
    }
}
