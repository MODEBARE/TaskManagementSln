using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Application.ApplicationServices;
using TaskManagementSystem.Application.IApplicationServices;
using TaskManagementSystem.Core.Entities;

namespace TaskManagementSystem.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationAppService _notificationAppService;

        public NotificationController(INotificationAppService notificationAppService)
        {
            _notificationAppService = notificationAppService;

        }

        [HttpGet]
        public async Task<ActionResult<List<Notification>>> GetAllNotifications()
        {
            var notification = await _notificationAppService.GetAllNotification();
            return Ok(notification);
        }

        [HttpGet("{notificationId}")]
        public async Task<ActionResult<Notification>> GetProject(int notificationId)
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
    }
}
