using MediatR;
using ProjectManagement.Application.DTO.StatusDtos;
using ProjectManagement.Application.Statuses.Queries;
using ProjectManagement.Domain.Interfaces;

namespace ProjectManagement.Application.Statuses.Handlers
{
    public class GetStatusByIdQueryHandler : IRequestHandler<GetStatusByIdQuery, StatusDto>
    {
        private readonly IStatusRepository _repository;

        public GetStatusByIdQueryHandler(IStatusRepository repository)
        {
            _repository = repository;
        }

        public async Task<StatusDto> Handle(GetStatusByIdQuery request, CancellationToken cancellationToken)
        {
            var status = await _repository.GetByIdAsync(request.StatusId);
            if (status == null)
                return null;

            return new StatusDto
            {
                StatusId = status.StatusId,
                Name = status.Name
            };
        }
    }
}
