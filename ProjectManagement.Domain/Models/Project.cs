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
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int StatusId { get; set; }
        public Status Status { get; set; }

        public ICollection<TaskWork> Tasks { get; set; }
        public ICollection<Milestone> Milestones { get; set; }
    }

}
