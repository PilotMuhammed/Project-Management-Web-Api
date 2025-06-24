using MediatR;
using ProjectManagement.Application.TaskWorks.Commands;
using ProjectManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.TaskWorks.Handlers
{
    public class DeleteTaskWorkCommandHandler : IRequestHandler<DeleteTaskWorkCommand>
    {
        private readonly ITaskWorkRepository _repository;

        public DeleteTaskWorkCommandHandler(ITaskWorkRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteTaskWorkCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.TaskId);
            return Unit.Value;
        }
    }
}
