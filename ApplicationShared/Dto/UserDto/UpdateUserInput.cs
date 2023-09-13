using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationShared.Dto.UserDto
{
    public class UpdateUserInput
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public int? NotificationId { get; set; }

        public int? TaskId { get; set; }
    }
}
