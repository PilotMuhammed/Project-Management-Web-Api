using ProjectManagement.Domain.Models;

namespace ProjectManagement.Domain.Interfaces
{
    public interface IStatusRepository
    {
        Task<Status> GetByIdAsync(int statusId);
        Task<IEnumerable<Status>> GetAllAsync();
        Task AddAsync(Status status);
        Task UpdateAsync(Status status);
        Task DeleteAsync(int status);

    }
}
