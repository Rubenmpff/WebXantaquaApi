using System;
using System.ComponentModel.DataAnnotations;

public class Photo
{
    public int Id { get; set; }

    [Required]
    [StringLength(500, ErrorMessage = "A URL da foto deve ter no máximo 500 caracteres.")]
    public string Url { get; set; }

    public int ProjectId { get; set; }
    public Project Project { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
