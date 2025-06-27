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
        public required string FullName { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }

        public int RoleId { get; set; }
        public required Role Role { get; set; }

        public required ICollection<TaskWork> TaskWorks { get; set; }
        public required ICollection<Notification> Notifications { get; set; }
        public required ICollection<Comment> Comments { get; set; }
        public required ICollection<ActivityLog> ActivityLogs { get; set; }
    }

}
