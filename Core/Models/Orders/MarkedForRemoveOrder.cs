namespace Core.Models.Orders;

public class MarkedForRemoveOrder : IdableEntity
{
    public MarkedForRemoveOrder(Guid id, DateTime createdAt)
    {
        Id = id;
        CreatedAt = createdAt;
    }
    
    public Guid Id { get; protected set; }
    public DateTime CreatedAt { get; protected set; }
}