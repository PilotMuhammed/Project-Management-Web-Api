using ProjectManagement.Application.DTO;
using ProjectManagement.Application.DTO.TagDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Services.Interfaces
{
    public interface ITagService
    {
        Task<IEnumerable<TagDto>> GetAllAsync();
        Task<TagDto> GetByIdAsync(int id);
        Task<TagDto> CreateAsync(TagDto dto);
        Task<TagDto> UpdateAsync(int id, TagDto dto);
        Task DeleteAsync(int id);
    }
}
