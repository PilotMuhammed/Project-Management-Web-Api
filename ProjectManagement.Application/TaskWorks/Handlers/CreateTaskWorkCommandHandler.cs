using MediatR;
using ProjectManagement.Application.TaskWorks.Commands;
using ProjectManagement.Domain.Models;
using ProjectManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.TaskWorks.Handlers
{
    public class CreateTaskWorkCommandHandler : IRequestHandler<CreateTaskWorkCommand, int>
    {
        private readonly ITaskWorkRepository _repository;

        public CreateTaskWorkCommandHandler(ITaskWorkRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateTaskWorkCommand request, CancellationToken cancellationToken)
        {
            var taskWork = new TaskWork
            {
                ProjectId = request.ProjectId,
                AssignedUserId = request.AssignedUserId,
                Title = request.Title,
                Description = request.Description,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                StatusId = request.StatusId,
                PriorityId = request.PriorityId
            };

            await _repository.AddAsync(taskWork);
            return taskWork.TaskWorkId;
        }
    }
}
