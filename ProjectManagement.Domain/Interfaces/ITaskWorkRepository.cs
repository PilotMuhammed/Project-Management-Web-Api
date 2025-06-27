using ProjectManagement.Domain.Models;

namespace ProjectManagement.Domain.Interfaces
{
    public interface ITaskWorkRepository
    {
        Task<TaskWork> GetByIdAsync(int taskWorkId);
        Task<IEnumerable<TaskWork>> GetAllAsync();
        Task AddAsync(TaskWork taskWork);
        Task UpdateAsync(TaskWork taskWork);
        Task DeleteAsync(int taskWorkId);
        Task<IEnumerable<TaskWork>> GetByProjectIdAsync(int projectId);
        Task<IEnumerable<TaskWork>> GetByAssigneeIdAsync(int assigneeId);
    }
}
