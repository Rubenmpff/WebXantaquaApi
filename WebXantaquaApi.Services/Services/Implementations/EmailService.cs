using SendGrid;
using SendGrid.Helpers.Mail;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using WebXantaquaApi.Services.Mapping.Dtos;
using WebXantaquaApi.Services.Services.Interfaces;
using System;
using WebXantaquaApi.Services.Validator;

namespace WebXantaquaApi.Services.Services.Implementations
{
    public class EmailService : IEmailService
    {
        private readonly SendGridClient _client;
        private readonly EmailAddress _fromAddress;

        public EmailService(IConfiguration configuration)
        {
            var apiKey = configuration["SendGrid:ApiKey"];
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new InvalidOperationException("A chave da API do SendGrid não está configurada.");
            }

            var fromEmail = configuration["SendGrid:FromEmail"] ?? "info@yourcompany.com";
            var fromName = configuration["SendGrid:FromName"] ?? "Your Company Name";

            _client = new SendGridClient(apiKey);
            _fromAddress = new EmailAddress(fromEmail, fromName);
        }

        public async Task SendEmailAsync(EmailRequest emailRequest)
        {
            var to = new EmailAddress(emailRequest.To);
            if (!EmailValidator.IsValidEmail(to.Email))
            {
                throw new ArgumentException("O endereço de e-mail fornecido é inválido.");
            }

            var msg = MailHelper.CreateSingleEmail(_fromAddress, to, emailRequest.Subject, emailRequest.Body, null);

            try
            {
                var response = await _client.SendEmailAsync(msg);
                if (!response.IsSuccessStatusCode)
                {
                    // Logar o código de resposta e a resposta
                }
            }
            catch (Exception)
            {
                // Logar a exceção
                throw; // Ou lidar de outra forma adequada
            }
        }
    }
}
