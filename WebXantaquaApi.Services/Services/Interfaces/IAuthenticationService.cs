using System.Threading.Tasks;
using WebXantaquaApi.Services.Mapping.Dtos;

namespace WebXantaquaApi.Services.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResultDto> RegisterAsync(RegisterDto userForRegistration);
        Task<AuthenticationResultDto> LoginAsync(LoginDto userForLogin);
    }
}
