using ApplicationShared.Dto.NotificationDto;
using ApplicationShared.Dto.ProjectDto;
using ApplicationShared.Dto.TaskDto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Application.IApplicationServices;
using TaskManagementSystem.Core.Entities;
using TaskManagementSystem.Infrastucture.Interfaces;

namespace TaskManagementSystem.Application.ApplicationServices
{
    public class NotificationAppService: INotificationAppService
    {
        private readonly INotificationRepository<Notification, int> _notificationRepository;
        private readonly IMapper _mapper;

        public NotificationAppService(INotificationRepository<Notification, int> notificationRepository, IMapper mapper)
        {
            _notificationRepository = notificationRepository;
            _mapper = mapper;

        }

        public async Task<NotificationDto> GetNotification(int id)
        {
            var notification = await _notificationRepository.GetByIdAsync(id);
            var notificationDto = _mapper.Map<NotificationDto>(notification);
            return notificationDto;
        }

        public async Task<List<NotificationDto>> GetAllNotification()
        {
            var notification = await _notificationRepository.GetAllAsync();
            var notificationDtos = _mapper.Map<List<NotificationDto>>(notification);
            return notificationDtos;
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
