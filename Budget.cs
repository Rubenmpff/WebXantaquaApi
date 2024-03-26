// Representa um orçamento dentro de um projeto.
public class Budget
{
    public int Id { get; set; } // Identificador único do orçamento.
    public string Description { get; set; } // Descrição dos itens ou serviços orçamentados.
    public decimal TotalValue { get; set; } // Valor total estimado para o orçamento.
    public DateTime ValidUntil { get; set; } // Data até a qual o orçamento é válido.
    public BudgetStatus Status { get; set; } = BudgetStatus.Pending; // Status inicial do orçamento, definido como Pendente.

    public int ProjectId { get; set; } // Chave estrangeira que referencia o projeto associado.
    public Project Project { get; set; } // Propriedade de navegação para o projeto relacionado.

    // Construtor para criar um orçamento com detalhes básicos.
    public Budget(string description, decimal totalValue, DateTime validUntil)
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