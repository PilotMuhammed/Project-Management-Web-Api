using MediatR;
using ProjectManagement.Application.DTO;
using ProjectManagement.Application.DTO.TaskWorkDtos;
using ProjectManagement.Application.TaskWorks.Queries;
using ProjectManagement.Domain.Interfaces;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.TaskWorks.Handlers
{
    public class GetAllTaskWorksQueryHandler : IRequestHandler<GetAllTaskWorksQuery, IEnumerable<TaskWorkDto>>
    {
        private readonly ITaskWorkRepository _repository;

        public GetAllTaskWorksQueryHandler(ITaskWorkRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TaskWorkDto>> Handle(GetAllTaskWorksQuery request, CancellationToken cancellationToken)
        {
            var taskWorks = await _repository.GetAllAsync();
            
            return taskWorks.Select(t => new TaskWorkDto
            {
                TaskId = t.TaskWorkId,
                ProjectId = t.ProjectId,
                AssignedUserId = t.AssignedUserId,
                Title = t.Title,
                Description = t.Description,
                StartDate = t.StartDate,
                EndDate = t.EndDate,
                StatusId = t.StatusId,
                PriorityId = t.PriorityId
            }).ToList();
        }
    }
}
