using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.DTO.TaskWorkDtos
{
    public class CreateTaskWorkDto
    {
        public int ProjectId { get; set; }
        public int AssignedUserId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int StatusId { get; set; }
        public int PriorityId { get; set; }
    }

    public class UpdateTaskWorkDto
    {
        public int TaskId { get; set; }
        public int ProjectId { get; set; }
        public int AssignedUserId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int StatusId { get; set; }
        public int PriorityId { get; set; }
    }

    public class TaskWorkDto
    {
        public int TaskId { get; set; }
        public int ProjectId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? ProjectName { get; set; }
        public string? AssignedUserName { get; set; }
        public int AssignedUserId { get; set; }
        public string? StatusName { get; set; }
        public int StatusId { get; set; }
        public string? PriorityName { get; set; }
        public int PriorityId { get; set; }
    }
}
