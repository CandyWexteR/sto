namespace Core.Models.Orders;

public class OrderItem : IdableEntity
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public Guid OrderedComponent { get; set; }
    public uint ComponentsCount { get; set; }
}