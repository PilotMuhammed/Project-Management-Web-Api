using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.DTO.NotificationDtos
{
    public class CreateNotificationDto
    {
        public int UserId { get; set; }
        public string Message { get; set; }
    }

    public class NotificationDto
    {
        public int NotificationId { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserFullName { get; set; }
    }
}

