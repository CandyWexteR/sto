using Newtonsoft.Json;

namespace Core.Models.Chat;

public class ChatMessage : IdableEntity
{
    [JsonConstructor]
    private ChatMessage(Guid id, string message, DateTime createdAt, Guid authorId, Guid ticketId)
    {
        Id = id;
        Message = message;
        CreatedAt = createdAt;
        AuthorId = authorId;
        TicketId = ticketId;
    }
    
    public Guid Id { get; protected set; }
    public string Message { get; protected set; }
    public DateTime CreatedAt { get; protected set; }
    public Guid AuthorId { get; protected set; }
    public Guid TicketId { get; protected set; }

    public static ChatMessage Create(Guid id, string message, DateTime createdAt, Guid authorId, Guid bugId)
    {
        //TODO: Валидация
        
        return new ChatMessage(id, message, createdAt, authorId, bugId);
    }
}