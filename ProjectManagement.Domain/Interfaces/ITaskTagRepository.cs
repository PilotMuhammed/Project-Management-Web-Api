using ProjectManagement.Domain.Models;

namespace ProjectManagement.Domain.Interfaces
{
    public interface ITaskTagRepository
    {
        Task<TaskTag> GetByIdAsync(int taskId, int tagId);
        Task<IEnumerable<TaskTag>> GetAllAsync();
        Task AddAsync(TaskTag taskTag);
        Task DeleteAsync(int taskId, int tagId);
        Task<IEnumerable<TaskTag>> GetByTaskWorkIdAsync(int taskWorkId);
    }
}
