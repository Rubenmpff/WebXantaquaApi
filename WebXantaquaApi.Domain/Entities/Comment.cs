using System;

public class Comment
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool IsApproved { get; set; } = false;

    public Client User { get; set; }
    public int? ProjectId { get; set; }
    public Project Project { get; set; }
}