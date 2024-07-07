using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace WebKrpcApi.Services.Services.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateTokenAsync(IdentityUser user);

    }

}
