using ProjectManagement.Domain.Models;

namespace ProjectManagement.Domain.Interfaces
{
    public interface ICommentRepository
    {
        Task<Comment> GetByIdAsync(int commentId);
        Task<IEnumerable<Comment>> GetAllAsync();
        Task AddAsync(Comment comment);
        Task DeleteAsync(int commentId);
        Task UpdateAsync(Comment comment);
        Task<IEnumerable<Comment>> GetByTaskWorkIdAsync(int taskWorkId);
    }
}
