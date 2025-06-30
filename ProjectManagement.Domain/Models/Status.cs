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
        public string? Name { get; set; }

        public ICollection<Project> Projects { get; set; } = new List<Project>();
        public ICollection<TaskWork> TaskWorks { get; set; } = new List<TaskWork>();
        public ICollection<Milestone> Milestones { get; set; } = new List<Milestone>();
    }

}
