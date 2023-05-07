using System.Security.Cryptography;
using Newtonsoft.Json;

namespace Core.Models.Orders;

public class Order : IdableEntity
{
    [JsonConstructor]
    public Order(Guid id, string title, string? description, DateTime createdAt, DateTime? orderDelivered,
        Guid responsibleUserId)
    {
        Id = id;
        Title = title;
        Description = description;
        CreatedAt = createdAt;
        OrderDelivered = orderDelivered;
        ResponsibleUserId = responsibleUserId;
    }

    public Guid Id { get; protected set; }
    public string Title { get; protected set; }
    public string? Description { get; protected set; }
    public DateTime CreatedAt { get; protected set; }
    public DateTime? OrderDelivered { get; protected set; }
    public Guid ResponsibleUserId { get; protected set; }

    public static Order Create(Guid id, string title, string? description, DateTime createdAt, Guid responsibleUserId)
    {
        return new Order(id, title, description, createdAt, null, responsibleUserId);
    }

    public void ChangeInfo(string title, string? description, DateTime createdAt, DateTime? orderDelivered)
    {
        Title = title;
        Description = description;
        CreatedAt = createdAt;
        OrderDelivered = orderDelivered;
    }
}