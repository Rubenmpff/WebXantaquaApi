
namespace WebKrpcApi.Services.Mapping.Dtos
{
    public class EmailRequest
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        // Pode adicionar mais propriedades se necessário, como Cc, Bcc, Attachments, etc.
    }

}
