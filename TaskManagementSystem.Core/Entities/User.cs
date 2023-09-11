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
        public virtual string Name { get; set; }

        [Required]
        public virtual string Email { get; set; }

        public List<Notification>? Notifications { get; set; }

        // Navigation property
        public List<Tasks> Tasks { get; set; }
    }
}
