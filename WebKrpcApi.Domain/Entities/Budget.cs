using System;
using System.ComponentModel.DataAnnotations;

public class Budget
{
    public int Id { get; set; }

    [Required(ErrorMessage = "A descrição do orçamento é obrigatória.")]
    [StringLength(500, ErrorMessage = "A descrição não deve exceder 500 caracteres.")]
    public string Description { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "O valor total deve ser maior que zero.")]
    public decimal TotalValue { get; set; }

    [Required]
    public DateTime ValidUntil { get; set; }

    public BudgetStatus Status { get; set; } = BudgetStatus.Pending;

    public int ProjectId { get; set; }
    public Project Project { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

    public Budget(string description, decimal totalValue, DateTime validUntil)
    {
        Description = description;
        TotalValue = totalValue;
        ValidUntil = validUntil;
    }

    public Budget() { }

    public void UpdateStatus(BudgetStatus newStatus)
    {
        if ((newStatus == BudgetStatus.Sent && Status == BudgetStatus.Pending) ||
            (newStatus == BudgetStatus.Approved && Status == BudgetStatus.Sent) ||
            (newStatus == BudgetStatus.Rejected && Status != BudgetStatus.Approved))
        {
            Status = newStatus;
            LastUpdated = DateTime.UtcNow;
        }
        else
        {
            throw new InvalidOperationException("Transição de status inválida.");
        }
    }
}

public enum BudgetStatus
{
    Pending,
    Sent,
    Approved,
    Rejected
}