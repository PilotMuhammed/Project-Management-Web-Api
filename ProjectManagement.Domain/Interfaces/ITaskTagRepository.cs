using ProjectManagement.Domain.Models;

namespace ProjectManagement.Domain.Interfaces
{
    public interface ITaskTagRepository
    {
        Task<TaskTag> GetByIdAsync(int taskTagId);
        Task<IEnumerable<TaskTag>> GetAllAsync();
        Task AddAsync(TaskTag taskTag);
        Task DeleteAsync(int taskTagId);
        Task<IEnumerable<TaskTag>> GetByTaskWorkIdAsync(int taskWorkId);
    }
}
