using System;
using System.ComponentModel.DataAnnotations;

namespace WebXantaquaApi.Services.Mapping.Dtos 
{

    // Representa um orçamento dentro de um projeto.
    public class BudgetDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "O valor total deve ser maior que zero.")]
        public decimal TotalValue { get; set; }

        [Required]
        public DateTime ValidUntil { get; set; }

        public BudgetStatus Status { get; set; }

        [Required]
        public int ProjectId { get; set; }
    }

    // Define os possíveis estados de um orçamento.
    public enum BudgetStatus
    {
        Pending, // Pendente
        Sent, // Enviado
        Approved, // Aprovado
        Rejected // Rejeitado
    }
}