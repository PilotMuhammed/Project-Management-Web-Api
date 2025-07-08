using System.Threading.Tasks;
using ProjectManagement.Application.DTO; 

namespace ProjectManagement.Application.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponseDto> LoginAsync(LoginRequestDto request);

        Task<RegisterResponseDto> RegisterAsync(RegisterRequestDto request);
    }
}
