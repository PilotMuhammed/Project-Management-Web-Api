using ProjectManagement.Application.DTO;
using ProjectManagement.Application.DTO.AttachmentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Services.Interfaces
{
    public interface IAttachmentService
    {
        Task<IEnumerable<AttachmentDto>> GetAllAsync();
        Task<AttachmentDto> GetByIdAsync(int id);
        Task<AttachmentDto> CreateAsync(AttachmentDto dto);
        Task<AttachmentDto> UpdateAsync(int id, AttachmentDto dto);
        Task DeleteAsync(int id);
    }
}

