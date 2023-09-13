using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Core.Entities;

namespace ApplicationShared.Dto.NotificationDto
{
    public class NotificationDto
    {
        
        public string Type { get; set; }

        public string Message { get; set; }

        public DateTime Timestamp { get; set; }

        public bool IsRead { get; set; }

        public User User { get; set; }
    }
}
