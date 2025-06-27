using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Domain.Models
{
    public class Status
    {
        public int StatusId { get; set; }
        public required string Name { get; set; }

        public required ICollection<Project> Projects { get; set; }
        public required ICollection<TaskWork> TaskWorks { get; set; }
        public required ICollection<Milestone> Milestones { get; set; }
    }

}
