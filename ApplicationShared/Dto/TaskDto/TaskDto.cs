using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Core.Entities.Enums;
using TaskManagementSystem.Core.Entities;

namespace ApplicationShared.Dto.TaskDto
{
    public class TaskDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public Priority Priority { get; set; }

        [Required]
        public Status Status { get; set; }

        public Project Project { get; set; }

        public User User { get; set; }
    }
}
