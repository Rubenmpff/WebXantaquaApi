using System;


namespace WebKrpcApi.Services.Mapping.Dtos 
{

    // Representa um orçamento dentro de um projeto.
    public class BudgetDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal TotalValue { get; set; }
        public DateTime ValidUntil { get; set; }
        public BudgetStatus Status { get; set; }

        // Referência ao ID do projeto, não o objeto inteiro
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