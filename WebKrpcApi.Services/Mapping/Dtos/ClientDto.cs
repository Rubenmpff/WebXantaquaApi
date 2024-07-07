using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebKrpcApi.Services.Mapping.Dtos
{
    // Representa um cliente no sistema.
    public class ClientDto
    {
        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string Name { get; set; }

        [Phone(ErrorMessage = "Número de telefone inválido.")]
        public string Phone { get; set; }

        public bool AgreedToTermsAndConditions { get; set; }
        public bool ConsentForAdvertising { get; set; }

        // Lista de IDs de projetos associados ao cliente.
        public List<int> ProjectIds { get; set; } = new List<int>();

        // Construtor sem parâmetros
        public ClientDto() { }

        // Construtor com parâmetros para facilitar a criação de um novo cliente.
        public ClientDto(string name, string email, string phone)
        {
            Name = name;
            Email = email;
            Phone = phone;
        }
    }
}