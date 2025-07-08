using ProjectManagement.Application.DTO.CommentDtos;
using ProjectManagement.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Services.Interfaces
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentDto>> GetAllAsync();
        Task<CommentDto> GetByIdAsync(int id);
        Task<CommentDto> CreateAsync(CommentDto dto);
        Task<CommentDto> UpdateAsync(int id, CommentDto dto);
        Task DeleteAsync(int id);
    }
}

