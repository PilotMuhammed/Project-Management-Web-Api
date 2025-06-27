using ProjectManagement.Domain.Models;

namespace ProjectManagement.Domain.Interfaces
{
    public interface IAttachmentRepository
    {
        Task<Attachment> GetByIdAsync(int attachmentId);
        Task<IEnumerable<Attachment>> GetAllAsync();
        Task AddAsync(Attachment attachment);
        Task DeleteAsync(int attachmentId);
        Task<IEnumerable<Attachment>> GetByTaskWorkIdAsync(int taskWorkId);
    }
}
