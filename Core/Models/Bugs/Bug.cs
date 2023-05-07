using Newtonsoft.Json;

namespace Core.Models.Bugs;

public class Bug : IdableEntity
{
    [JsonConstructor]
    private Bug(Guid id, string title, string description, DateTime createdAt, DateTime? completedAt, Guid ticketId)
    {
        Id = id;
        Title = title;
        Description = description;
        CreatedAt = createdAt;
        CompletedAt = completedAt;
        TicketId = ticketId;
    }
    
    public Guid Id { get; protected set; }
    public Guid TicketId { get; protected set; }
    public string Title { get; protected set; }
    public string Description { get; protected set; }
    public DateTime CreatedAt { get; protected set; }
    public DateTime? CompletedAt { get; protected set; }

    public static Bug Create(Guid id, Guid ticketId, string title, string description, DateTime createdAt, DateTime? completedAt)
    {
        return new Bug(id, title, description, createdAt, completedAt, ticketId);
    }

    public void UpdateInfo(string title, string description, DateTime? completedAt)
    {
        //TODO: Валидация
        
        Title = title;
        Description = description;
        CompletedAt = completedAt;
    }
}