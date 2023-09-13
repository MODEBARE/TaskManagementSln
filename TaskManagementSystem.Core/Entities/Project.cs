using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Core.Entities
{
    public class Project: BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public virtual string Name { get; set; }

        [Required]
        [MaxLength(250)]
        public virtual string Description { get; set; }

        // Navigation property
        [ForeignKey("TaskId")]
        public virtual Tasks? Tasks { get; set; }
        public virtual int? TaskId { get; set; }
    }
}
