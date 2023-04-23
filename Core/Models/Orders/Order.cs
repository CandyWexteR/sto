namespace Core.Models.Orders;

public class Order : IdableEntity
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? OrderDelivered { get; set; }
}