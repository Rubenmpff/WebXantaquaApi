using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebKrpcApi.Services.Mapping.Dtos
{
    // Representa um projeto associado a um cliente.
    public class ProjectDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        public ProjectStatus Status { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EstimatedEndDate { get; set; }

        [Required]
        public int ClientId { get; set; }

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