using ProjectManagement.Application.DTO;
using ProjectManagement.Application.DTO.RoleDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Services.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleDto>> GetAllAsync();
        Task<RoleDto> GetByIdAsync(int id);
        Task<RoleDto> CreateAsync(RoleDto dto);
        Task<RoleDto> UpdateAsync(int id, RoleDto dto);
        Task DeleteAsync(int id);
    }
}

