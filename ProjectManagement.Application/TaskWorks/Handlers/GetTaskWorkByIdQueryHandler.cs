using MediatR;
using ProjectManagement.Application.DTO;
using ProjectManagement.Application.DTO.TaskWorkDtos;
using ProjectManagement.Application.TaskWorks.Queries;
using ProjectManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.TaskWorks.Handlers
{
    public class GetTaskWorkByIdQueryHandler : IRequestHandler<GetTaskWorkByIdQuery, TaskWorkDto>
    {
        private readonly ITaskWorkRepository _repository;

        public GetTaskWorkByIdQueryHandler(ITaskWorkRepository repository)
        {
            _repository = repository;
        }

        public async Task<TaskWorkDto> Handle(GetTaskWorkByIdQuery request, CancellationToken cancellationToken)
        {
            var t = await _repository.GetByIdAsync(request.TaskId);
            if (t == null)
                return null;

            return new TaskWorkDto
            {
                TaskId = t.TaskId,
                ProjectId = t.ProjectId,
                AssignedUserId = t.AssignedUserId,
                Title = t.Title,
                Description = t.Description,
                StartDate = t.StartDate,
                EndDate = t.EndDate,
                StatusId = t.StatusId,
                PriorityId = t.PriorityId
            };
        }
    }
}

