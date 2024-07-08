using System.Threading.Tasks;
using WebXantaquaApi.Services.Mapping.Dtos;

namespace WebXantaquaApi.Services.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(EmailRequest emailRequestDto);
    }

}
