using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProjectManagement.Domain.Models
{
    public class TaskWork
    {
        public int TaskWorkId { get; set; }

        public int ProjectId { get; set; }
        public required Project Project { get; set; }

        public int AssignedUserId { get; set; }
        public required User AssignedUser { get; set; }

        public required string Title { get; set; }
        public required string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int StatusId { get; set; }
        public required Status Status { get; set; }

        public int PriorityId { get; set; }
        public required Priority Priority { get; set; }

        public required ICollection<Comment> Comments { get; set; }
        public required ICollection<Attachment> Attachments { get; set; }
        public required ICollection<TaskTag> TaskTags { get; set; }
    }

}
