using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Core.Entities
{
    public class User: BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public virtual string Name { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public virtual string Email { get; set; }

        public List<Notification>? Notifications { get; set; }
        public int NotificationId { get; set; }

        // Navigation property
        public List<Tasks> Tasks { get; set; }
        public int TaskId { get; set; }
    }
}
