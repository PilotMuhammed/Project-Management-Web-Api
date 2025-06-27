using ProjectManagement.Domain.Models;

namespace ProjectManagement.Domain.Interfaces
{
    public interface IActivityLogRepository
    {
        Task<ActivityLog> GetByIdAsync(int activityLogId);
        Task<IEnumerable<ActivityLog>> GetAllAsync();
        Task AddAsync(ActivityLog activityLog);
        Task<IEnumerable<ActivityLog>> GetByUserIdAsync(int userId);
    }
}
