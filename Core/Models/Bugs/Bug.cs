﻿namespace Core.Models.Bugs;

public class Bug : IdableEntity
{
    private Bug(Guid id, string title, string description, DateTime createdAt, DateTime? completedAt)
    {
        Id = id;
        Title = title;
        Description = description;
        CreatedAt = createdAt;
        CompletedAt = completedAt;
    }
    
    public Guid Id { get; protected set; }
    public Guid TicketId { get; protected set; }
    public string Title { get; protected set; }
    public string Description { get; protected set; }
    public DateTime CreatedAt { get; protected set; }
    public DateTime? CompletedAt { get; protected set; }

    public static Bug Create(Guid id, string title, string description, DateTime createdAt, DateTime? completedAt)
    {
        return new Bug(id, title, description, createdAt, completedAt);
    }
}