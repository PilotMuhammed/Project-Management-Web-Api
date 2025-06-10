using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Domain.Models
{
    public class Milestone
    {
        public int MilestoneId { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public string Name { get; set; }
        public DateTime DueDate { get; set; }

        public int StatusId { get; set; }
        public Status Status { get; set; }
    }

}
