using ApplicationShared.Dto.NotificationDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Application.ApplicationServices;
using TaskManagementSystem.Application.IApplicationServices;
using TaskManagementSystem.Core.Entities;
using TaskManagementSystem.Infrastucture.Interfaces;

namespace TaskManagementSystem.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationAppService _notificationAppService;
        private readonly INotificationRepository<Notification, int> _notificationRepository;

        public NotificationController(INotificationAppService notificationAppService, INotificationRepository<Notification, int> notificationRepository)
        {
            _notificationAppService = notificationAppService;
            _notificationRepository = notificationRepository;

        }

        [HttpGet]
        public async Task<ActionResult<List<NotificationDto>>> GetAllNotifications()
        {
            var notification = await _notificationAppService.GetAllNotification();
            return Ok(notification);
        }

        [HttpGet("{notificationId}")]
        public async Task<ActionResult<NotificationDto>> GetNotification(int notificationId)
        {
            var notification = await _notificationAppService.GetNotification(notificationId);
            if (notification == null)
            {
                return NotFound();
            }

            return Ok(notification);
        }

        [HttpDelete("{notificationId}")]
        public async Task<IActionResult> DeleteNotification(int notificationId)
        {
            await _notificationAppService.DeleteNotification(notificationId);
            return NoContent();
        }

        // Notifications Controller
        // PUT: api/notifications/1/mark-read
        [HttpPut("{notificationId}/mark-read")]
        public async Task<IActionResult> MarkNotificationAsRead(int notificationId)
        {
            var notification = await _notificationRepository.GetAsync(notificationId);

            if (notification == null)
            {
                return NotFound();
            }

            notification.IsRead = true;
            await _notificationRepository.UpdateAsync(notification);

            return NoContent();
        }

        // PUT: api/notifications/1/mark-unread
        [HttpPut("{notificationId}/mark-unread")]
        public async Task<IActionResult> MarkNotificationAsUnread(int notificationId)
        {
            var notification = await _notificationRepository.GetAsync(notificationId);

            if (notification == null)
            {
                return NotFound();
            }

            notification.IsRead = false;
            await _notificationRepository.UpdateAsync(notification);

            return NoContent();
        }

    }
}
