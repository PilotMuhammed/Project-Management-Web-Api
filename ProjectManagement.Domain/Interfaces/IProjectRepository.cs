
using ProjectManagement.Domain.Models;

namespace ProjectManagement.Domain.Interfaces
{
    public interface IProjectRepository
    {
        Task<Project> GetByIdAsync(int projectId);
        Task<IEnumerable<Project>> GetAllAsync();
        Task AddAsync(Project project);
        Task UpdateAsync(Project project);
        Task DeleteAsync(int projectId);
        Task<IEnumerable<Project>> GetByOwnerIdAsync(int ownerId);
    }
}
