using System;
using System.Collections.Generic;

namespace WebKrpcApi.Services.Mapping.Dtos
{
    // Representa um projeto associado a um cliente.
    public class ProjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ProjectStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EstimatedEndDate { get; set; }

        // Referência ao ID do cliente, não o objeto inteiro para evitar referências circulares
        public int ClientId { get; set; }

        // Uma lista de IDs de orçamentos em vez de objetos de orçamento completos
        public List<int> BudgetIds { get; set; } = new List<int>();
    }

    public enum ProjectStatus
    {
        Planning,
        InProgress,
        Completed,
        Canceled
    }
}