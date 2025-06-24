using MediatR;
using ProjectManagement.Application.Users.Commands;
using ProjectManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Users.Handlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUserRepository _repository;

        public DeleteUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.UserId);
            return Unit.Value;
        }
    }
}
