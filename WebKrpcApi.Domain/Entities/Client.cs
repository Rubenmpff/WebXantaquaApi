using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Client : IdentityUser
{
    [Required]
    [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
    public string Name { get; set; }

    public bool IsAdmin { get; set; }
    public bool AgreedToTermsAndConditions { get; set; }
    public bool ConsentForAdvertising { get; set; }

    public bool IsAuthorizedToComment { get; set; } = false; // Adiciona uma flag para indicar se o usuário pode comentar

    public ICollection<Project> Projects { get; set; } = new List<Project>();

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

    [EmailAddress(ErrorMessage = "O email inserido não é válido.")]
    public override string Email { get; set; }

    [Phone(ErrorMessage = "O número de telefone inserido não é válido.")]
    public override string PhoneNumber { get; set; }

    public Client() { }

    public Client(string name, string email, string phoneNumber)
    {
        UserName = email; // UserName é geralmente usado como um identificador único no Identity
        Email = email;
        PhoneNumber = phoneNumber;
        Name = name;
        CreatedAt = DateTime.UtcNow;
        LastUpdated = DateTime.UtcNow;
    }
}
