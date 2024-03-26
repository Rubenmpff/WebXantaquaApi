using System.Collections.Generic;

namespace WebKrpcApi.Services.Mapping.Dtos
{

    // Representa um cliente no sistema.
    public class ClientDto
    {
        public int Id { get; set; } // Identificador único para cada cliente, gerado automaticamente pelo banco de dados.
        public string Name { get; set; } // Nome do cliente.
        public string Email { get; set; } // Endereço de email do cliente.
        public string Phone { get; set; } // Número de telefone do cliente.
        public bool AgreedToTermsAndConditions { get; set; } // Indica se o cliente concordou com os Termos e Condições do serviço.
        public bool ConsentForAdvertising { get; set; } // Indica se o cliente deu consentimento para receber publicidade.
        public ICollection<ProjectDto> Projects { get; set; } = new List<ProjectDto>(); // Coleção de projetos associados a este cliente.


        // Construtor para facilitar a criação de um novo cliente com informações básicas.
        public ClientDto(string name, string email, string phone)
        {
            Name = name;
            Email = email;
            Phone = phone;
        }
    }
}