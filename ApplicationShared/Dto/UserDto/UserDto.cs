using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Core.Entities;

namespace ApplicationShared.Dto.UserDto
{
    public class UserDto
    {
        [Required]
        public virtual string Name { get; set; }

        [Required]
        public virtual string Email { get; set; }

        public Notification NotificationId { get; set; }

        public Tasks TaskId { get; set; }
    }
}
