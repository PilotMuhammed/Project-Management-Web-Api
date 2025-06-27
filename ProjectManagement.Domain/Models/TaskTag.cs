using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Domain.Models
{
    public class TaskTag
    {
        public int TaskId { get; set; }
        public required TaskWork Task { get; set; }

        public int TagId { get; set; }
        public required Tag Tag { get; set; }
    }

}
