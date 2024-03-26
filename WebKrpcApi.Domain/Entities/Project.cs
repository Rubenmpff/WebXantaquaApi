using System;
using System.Collections.Generic;


// Representa um projeto associado a um cliente.
public class Project
{
    public int Id { get; set; } // Identificador único do projeto.
    public string Name { get; set; } // Nome ou título do projeto.
    public string Description { get; set; } // Descrição detalhada do projeto.
    public ProjectStatus Status { get; set; } // Status atual do projeto.
    public DateTime StartDate { get; set; } // Data de início do projeto.
    public DateTime? EstimatedEndDate { get; set; } // Data estimada para a conclusão do projeto, pode ser nula se não estiver definida.

    public int ClientId { get; set; } // Chave estrangeira que referencia o cliente do projeto.
    public Client Client { get; set; } // Propriedade de navegação para o cliente associado.
    public ICollection<Budget> Budgets { get; set; } = new List<Budget>(); // Coleção de orçamentos relacionados a este projeto.

    // Construtor para criar um projeto com informações iniciais.
    public Project(string name, string description, DateTime startDate)
    {
        Name = name;
        Description = description;
        StartDate = startDate;
        Status = ProjectStatus.Planning; // Status inicial do projeto definido como Planejamento.
    }
}

// Define os possíveis estados de um projeto.
public enum ProjectStatus
{
    Planning, // Planejamento
    InProgress, // Em andamento
    Completed, // Concluído
    Canceled // Cancelado
}