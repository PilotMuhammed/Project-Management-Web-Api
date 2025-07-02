using MediatR;
using ProjectManagement.Application.Users.Commands;
using ProjectManagement.Domain.Interfaces;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Users.Handlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUserRepository _repository;

        public UpdateUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.UserId);
            if (user == null)
                throw new KeyNotFoundException("User not found");

            user.FullName = request.FullName;
            user.Username = request.Username;
            user.Email = request.Email;
            user.PasswordHash = request.PasswordHash;
            user.RoleId = request.RoleId;

            await _repository.UpdateAsync(user);
            return Unit.Value;
        }
    }
}
