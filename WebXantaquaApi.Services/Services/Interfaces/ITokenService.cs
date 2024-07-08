using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace WebXantaquaApi.Services.Services.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateTokenAsync(IdentityUser user);

    }

}
