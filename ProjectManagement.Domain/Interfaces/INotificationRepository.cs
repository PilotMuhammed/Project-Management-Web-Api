using ProjectManagement.Domain.Models;

namespace ProjectManagement.Domain.Interfaces
{
    public interface INotificationRepository
    {
        Task<Notification> GetByIdAsync(int notificationId);
        Task<IEnumerable<Notification>> GetAllAsync();
        Task AddAsync(Notification notification);
        Task UpdateAsync(Notification notification);
        Task DeleteAsync(int notificationId);
        Task<IEnumerable<Notification>> GetByUserIdAsync(int userId);
    }
}
