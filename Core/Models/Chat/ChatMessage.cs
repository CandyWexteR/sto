namespace Core.Models.Chat;

public class ChatMessage : IdableEntity
{
    public Guid Id { get; set; }
    public string Message { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid AuthorId { get; set; }
    public Guid BugId { get; set; }
}