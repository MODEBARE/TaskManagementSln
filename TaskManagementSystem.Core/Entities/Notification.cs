using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Core.Entities
{
    public class Notification : BaseEntity
    {
        [Required]
        public virtual string Type { get; set; }

        [Required]
        public virtual string Message { get; set; }

        [Required]
        public virtual DateTime Timestamp { get; set; }

        public virtual bool IsRead { get; set; }

        // User navigation property
        [ForeignKey("UserId")]
        public virtual User? User { get; set; }
        public virtual int ?UserId { get; set; }
    }
}
