using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.DTO.MilestoneDtos
{
    public class CreateMilestoneDto
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public int StatusId { get; set; }
    }

    public class UpdateMilestoneDto
    {
        public int MilestoneId { get; set; }
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public int StatusId { get; set; }
    }

    public class MilestoneDto
    {
        public int MilestoneId { get; set; }
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public string ProjectName { get; set; }
        public string StatusName { get; set; }
    }
}

