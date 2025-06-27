using ProjectManagement.Domain.Models;

namespace ProjectManagement.Domain.Interfaces
{
    public interface ITagRepository
    {
        Task<Tag> GetByIdAsync(int tagId);
        Task<IEnumerable<Tag>> GetAllAsync();
        Task AddAsync(Tag tag);
        Task UpdateAsync(Tag tag);
        Task DeleteAsync(int tagId);
    }
}
