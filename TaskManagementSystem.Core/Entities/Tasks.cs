using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Core.Entities.Enums;

namespace TaskManagementSystem.Core.Entities
{
    public class Tasks : BaseEntity
    {
        [Required]
        public virtual string Title { get; set; }

        [Required]
        public virtual string Description { get; set; }

        [Required]
        public virtual DateTime DueDate { get; set; }

        [Required]
        public Priority Priority { get; set; }

        [Required]
        public Status Status { get; set; }

        // Navigation properties
        [ForeignKey("ProjectId")]
        public Project? Project { get; set; }
        public int? ProjectId { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }
        public int? UserId { get; set; }
    }
}
