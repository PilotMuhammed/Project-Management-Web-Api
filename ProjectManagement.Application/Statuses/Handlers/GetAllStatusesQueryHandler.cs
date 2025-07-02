using MediatR;
using ProjectManagement.Application.DTO.StatusDtos;
using ProjectManagement.Application.Statuses.Queries;
using ProjectManagement.Domain.Interfaces;

namespace ProjectManagement.Application.Statuses.Handlers
{
    public class GetAllStatusesQueryHandler : IRequestHandler<GetAllStatusesQuery, IEnumerable<StatusDto>>
    {
        private readonly IStatusRepository _repository;

        public GetAllStatusesQueryHandler(IStatusRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<StatusDto>> Handle(GetAllStatusesQuery request, CancellationToken cancellationToken)
        {
            var statuses = await _repository.GetAllAsync();
            return statuses.Select(s => new StatusDto
            {
                StatusId = s.StatusId,
                Name = s.Name
            }).ToList();
        }
    }
}
