using System.Threading.Tasks;
using WebKrpcApi.Services.Mapping.Dtos;

namespace WebKrpcApi.Services.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResultDto> RegisterAsync(RegisterDto userForRegistration);
        Task<AuthenticationResultDto> LoginAsync(LoginDto userForLogin);
    }
}
