using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Domain.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int StatusId { get; set; }
        public required Status Status { get; set; }

        public required ICollection<TaskWork> TaskWorks { get; set; }
        public required ICollection<Milestone> Milestones { get; set; }
    }

}
