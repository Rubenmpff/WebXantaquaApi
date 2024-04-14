using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using WebKrpcApi.Services.Mapping.Dtos;
using WebKrpcApi.Services.Services.Interfaces;

namespace WebKrpcApi.Services.Services.Implementations
{
    public class EmailService : IEmailService
    {
        private readonly SendGridClient _client;
        private readonly EmailAddress _fromAddress;

        public EmailService(IConfiguration configuration)
        {
            var apiKey = configuration["SendGridApiKey"]; // A chave é carregada do Azure Key Vault automaticamente
            _client = new SendGridClient(apiKey);
            _fromAddress = new EmailAddress("info@yourcompany.com", "Your Company Name");
        }

        public async Task SendEmailAsync(EmailRequest emailRequest)
        {
            var to = new EmailAddress(emailRequest.To);
            var msg = MailHelper.CreateSingleEmail(_fromAddress, to, emailRequest.Subject, emailRequest.Body, null);
            await _client.SendEmailAsync(msg);
        }
    }
}