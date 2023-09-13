using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Core.Entities;

namespace ApplicationShared.Dto.UserDto
{
    public class CreateUserInput
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public int? NotificationId { get; set; }

        public int? TaskId { get; set; }
    }
}
