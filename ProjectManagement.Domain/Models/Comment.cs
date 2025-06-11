using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Domain.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int TaskId { get; set; }
        public TaskWork Task { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
