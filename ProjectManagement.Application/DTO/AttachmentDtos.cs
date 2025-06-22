using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.DTO.AttachmentDtos
{
    public class CreateAttachmentDto
    {
        public int TaskId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
    }

    public class AttachmentDto
    {
        public int AttachmentId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime UploadedAt { get; set; }
        public string TaskTitle { get; set; }
    }
}

