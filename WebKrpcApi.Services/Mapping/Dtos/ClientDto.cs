using System.Collections.Generic;

namespace WebKrpcApi.Services.Mapping.Dtos
{

    // Representa um cliente no sistema.
    public class ClientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool AgreedToTermsAndConditions { get; set; }
        public bool ConsentForAdvertising { get; set; }


        // Uma lista de IDs de projetos em vez de objetos de projeto completos
        public List<int> ProjectIds { get; set; } = new List<int>();


        // Construtor para facilitar a criação de um novo cliente com informações básicas.
        public ClientDto(string name, string email, string phone)
        {
            Name = name;
            Email = email;
            Phone = phone;
        }
    }
}