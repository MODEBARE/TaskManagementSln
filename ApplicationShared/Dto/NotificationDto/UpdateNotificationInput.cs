using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationShared.Dto.NotificationDto
{
    public class UpdateNotificationInput
    {
        public int Id { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        public bool IsRead { get; set; }

        public int? UserId { get; set; }
    }
}
