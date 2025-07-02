using MediatR;
using ProjectManagement.Application.Users.Commands;
using ProjectManagement.Domain.Interfaces;
using ProjectManagement.Domain.Models;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Users.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _repository;

        public CreateUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                FullName = request.FullName,
                Username = request.Username,
                Email = request.Email,
                PasswordHash = request.PasswordHash,
                RoleId = request.RoleId
            };

            await _repository.AddAsync(user);
            return user.UserId;
        }
    }
}
