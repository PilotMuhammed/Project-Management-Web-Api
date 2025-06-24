using MediatR;
using ProjectManagement.Application.DTO;
using ProjectManagement.Application.DTO.PriorityDtos;
using ProjectManagement.Application.Priorities.Queries;
using ProjectManagement.Domain.Interfaces;

namespace ProjectManagement.Application.Priorities.Handlers
{
    public class GetPriorityByIdQueryHandler : IRequestHandler<GetPriorityByIdQuery, PriorityDto>
    {
        private readonly IPriorityRepository _repository;

        public GetPriorityByIdQueryHandler(IPriorityRepository repository)
        {
            _repository = repository;
        }

        public async Task<PriorityDto> Handle(GetPriorityByIdQuery request, CancellationToken cancellationToken)
        {
            var priority = await _repository.GetByIdAsync(request.PriorityId);
            if (priority == null)
                return null;

            return new PriorityDto
            {
                PriorityId = priority.PriorityId,
                Name = priority.Name
            };
        }
    }
}
