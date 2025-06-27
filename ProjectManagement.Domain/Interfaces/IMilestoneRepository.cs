using ProjectManagement.Domain.Models;

namespace ProjectManagement.Domain.Interfaces
{
    public interface IMilestoneRepository
    {
        Task<Milestone> GetByIdAsync(int milestoneId);
        Task<IEnumerable<Milestone>> GetAllAsync();
        Task AddAsync(Milestone milestone);
        Task UpdateAsync(Milestone milestone);
        Task DeleteAsync(int milestoneId);
        Task<IEnumerable<Milestone>> GetByProjectIdAsync(int projectId);
    }
}
