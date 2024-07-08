using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Project
{
    public int Id { get; set; }

    [Required]
    [StringLength(200, ErrorMessage = "O nome do projeto deve ter no máximo 200 caracteres.")]
    public string Name { get; set; }

    [Required]
    [StringLength(1000, ErrorMessage = "A descrição do projeto deve ter no máximo 1000 caracteres.")]
    public string Description { get; set; }

    public ProjectStatus Status { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EstimatedEndDate { get; set; }

    public string ClientId { get; set; }
    public Client Client { get; set; }
    public ICollection<Budget> Budgets { get; set; } = new List<Budget>();
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public DateTime CreatedAt { get; set; }
    public DateTime LastUpdated { get; set; }
    public ProjectPriority Priority { get; set; }

    public Project(string name, string description, DateTime startDate)
    {
        Name = name;
        Description = description;
        StartDate = startDate;
        Status = ProjectStatus.Planning;
        CreatedAt = DateTime.UtcNow;
        LastUpdated = DateTime.UtcNow;
        Priority = ProjectPriority.Medium;
    }

    public Project() { }

    public void UpdateStatus(ProjectStatus newStatus)
    {
        Status = newStatus;
        LastUpdated = DateTime.UtcNow;

        if (newStatus == ProjectStatus.Completed || newStatus == ProjectStatus.Canceled)
        {
            SendStatusChangeNotification(newStatus);
        }
    }

    private void SendStatusChangeNotification(ProjectStatus status)
    {
        // Implemente sua lógica de notificação aqui.
        Console.WriteLine($"Notificação enviada: O status do projeto foi alterado para {status}.");
    }
}

public enum ProjectStatus
{
    Planning,
    InProgress,
    Completed,
    Canceled
}

public enum ProjectPriority
{
    Low,
    Medium,
    High
}
