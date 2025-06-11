using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Domain.Models
{
    public class Attachment
    {
        public int AttachmentId { get; set; }
        public int TaskId { get; set; }
        public TaskWork Task { get; set; }

        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime UploadedAt { get; set; }
    }

}
