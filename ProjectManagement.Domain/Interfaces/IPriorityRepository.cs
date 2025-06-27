using ProjectManagement.Domain.Models;

namespace ProjectManagement.Domain.Interfaces
{
    public interface IPriorityRepository
    {
        Task<Priority> GetByIdAsync(int priorityId);
        Task<IEnumerable<Priority>> GetAllAsync();
    }
}
