using System.Collections.Generic;


// Representa um cliente no sistema.
public class Client
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string PasswordHash { get; set; } // Campo para armazenar o hash da senha
    public bool IsAdmin { get; set; } // Campo para indicar se o usuário é um administrador
    public bool AgreedToTermsAndConditions { get; set; }
    public bool ConsentForAdvertising { get; set; }
    public ICollection<Project> Projects { get; set; } = new List<Project>();

    public Client(string name, string email, string phone)
    {
        Name = name;
        Email = email;
        Phone = phone;
    }
}