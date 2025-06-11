using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Domain.Models
{
    public class ActivityLog
    {
        public int ActivityLogId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public string Action { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
