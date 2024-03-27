using System.Collections.Generic;


// Representa um cliente no sistema.
public class Client
{
    public int Id { get; set; } // Identificador único para cada cliente, gerado automaticamente pelo banco de dados.
    public string Name { get; set; } // Nome do cliente.
    public string Email { get; set; } // Endereço de email do cliente.
    public string Phone { get; set; } // Número de telefone do cliente.
    public bool AgreedToTermsAndConditions { get; set; } // Indica se o cliente concordou com os Termos e Condições do serviço.
    public bool ConsentForAdvertising { get; set; } // Indica se o cliente deu consentimento para receber publicidade.
    public ICollection<Project> Projects { get; set; } = new List<Project>(); // Coleção de projetos associados a este cliente.

    //aaa

    // Construtor para facilitar a criação de um novo cliente com informações básicas.
    public Client(string name, string email, string phone)
    {
        Name = name;
        Email = email;
        Phone = phone;
    }
}