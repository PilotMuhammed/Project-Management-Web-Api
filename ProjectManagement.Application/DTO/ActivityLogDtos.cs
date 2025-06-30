using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.DTO.ActivityLogDtos
{
    public class ActivityLogDto
    {
        public int ActivityId { get; set; }
        public int UserId { get; set; }
        public string? Action { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? UserFullName { get; set; }
    }
}

