using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProjectManagement.Domain.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string? FullName { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }

        public int RoleId { get; set; }
        public Role? Role { get; set; }

        public ICollection<TaskWork> TaskWorks { get; set; } = new List<TaskWork>();
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<ActivityLog> ActivityLogs { get; set; } = new List<ActivityLog>();
    }

}
