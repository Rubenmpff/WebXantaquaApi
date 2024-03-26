using System;


namespace WebKrpcApi.Services.Mapping.Dtos 
{ 

    // Representa um orçamento dentro de um projeto.
    public class BudgetDto
    {
        public int Id { get; set; } // Identificador único do orçamento.
        public string Description { get; set; } // Descrição dos itens ou serviços orçamentados.
        public decimal TotalValue { get; set; } // Valor total estimado para o orçamento.
        public DateTime ValidUntil { get; set; } // Data até a qual o orçamento é válido.
        public BudgetStatus Status { get; set; } = BudgetStatus.Pending; // Status inicial do orçamento, definido como Pendente.


        public ProjectDto Project { get; set; } // Propriedade de navegação para o projeto relacionado.

        // Construtor para criar um orçamento com detalhes básicos.
        public BudgetDto(string description, decimal totalValue, DateTime validUntil)
        {
            Description = description;
            TotalValue = totalValue;
            ValidUntil = validUntil;
        }
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