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
        public string Name { get; set; }

        public ICollection<Project> Projects { get; set; }
        public ICollection<Task> Tasks { get; set; }
        public ICollection<Milestone> Milestones { get; set; }
    }

}
