using MediatR;
using ProjectManagement.Application.DTO.PriorityDtos;
using ProjectManagement.Application.Priorities.Queries;
using ProjectManagement.Domain.Interfaces;

namespace ProjectManagement.Application.Priorities.Handlers
{
    public class GetAllPrioritiesQueryHandler : IRequestHandler<GetAllPrioritiesQuery, IEnumerable<PriorityDto>>
    {
        private readonly IPriorityRepository _repository;

        public GetAllPrioritiesQueryHandler(IPriorityRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PriorityDto>> Handle(GetAllPrioritiesQuery request, CancellationToken cancellationToken)
        {
            var priorities = await _repository.GetAllAsync();
            return priorities.Select(p => new PriorityDto
            {
                PriorityId = p.PriorityId,
                Name = p.Name
            }).ToList();
        }
    }
}
