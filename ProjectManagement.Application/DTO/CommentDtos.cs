using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.DTO.CommentDtos
{
    public class CreateCommentDto
    {
        public int TaskId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
    }

    public class CommentDto
    {
        public int CommentId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserFullName { get; set; }
        public string TaskTitle { get; set; }
    }
}

