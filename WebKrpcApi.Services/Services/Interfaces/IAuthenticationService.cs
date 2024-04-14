using System.Threading.Tasks;
using WebKrpcApi.Services.Mapping.Dtos;

public interface IAuthenticationService
{
    Task<Client> FindByEmailAsync(string email);
    Task<Client> RegisterClientAsync(RegisterDto registerDto);
    Task<bool> CheckPasswordAsync(Client client, string password);
    Task<string> GenerateJwtToken(Client client);
}