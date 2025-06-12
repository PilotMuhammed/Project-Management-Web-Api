using MediatR;
using ProjectManagement.Application.Projects.Commands;
using ProjectManagement.Domain.Models;
using ProjectManagement.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Projects.Handlers
{
    public class CreateProjectCommandHandler(IProjectRepository repository) : IRequestHandler<CreateProjectCommand, int>
    {
        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Project
            {
                Name = request.Name,
                Description = request.Description,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                StatusId = request.StatusId
            };
            await repository.AddAsync(project);
            return project.ProjectId;
        }
    }
}
