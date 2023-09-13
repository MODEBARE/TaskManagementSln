using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Core.Entities;

namespace ApplicationShared.Dto.ProjectDto
{
    public class CreateProjectInput
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public int? TaskId { get; set; }

    }
}
