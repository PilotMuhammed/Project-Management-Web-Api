using MediatR;
using ProjectManagement.Application.TaskWorks.Commands;
using ProjectManagement.Domain.Interfaces;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.TaskWorks.Handlers
{
    public class UpdateTaskWorkCommandHandler : IRequestHandler<UpdateTaskWorkCommand>
    {
        private readonly ITaskWorkRepository _repository;

        public UpdateTaskWorkCommandHandler(ITaskWorkRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateTaskWorkCommand request, CancellationToken cancellationToken)
        {
            var taskWork = await _repository.GetByIdAsync(request.TaskId);
            if (taskWork == null)
                throw new KeyNotFoundException("TaskWork not found");

            taskWork.ProjectId = request.ProjectId;
            taskWork.AssignedUserId = request.AssignedUserId;
            taskWork.Title = request.Title;
            taskWork.Description = request.Description;
            taskWork.StartDate = request.StartDate;
            taskWork.EndDate = request.EndDate;
            taskWork.StatusId = request.StatusId;
            taskWork.PriorityId = request.PriorityId;

            await _repository.UpdateAsync(taskWork);
            return Unit.Value;
        }
    }
}
