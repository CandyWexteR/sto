using Newtonsoft.Json;

namespace Core.Models.Orders;

public class OrderItem : IdableEntity
{
    [JsonConstructor]
    public OrderItem(Guid id, Guid orderId, Guid orderedComponent, uint componentsCount)
    {
        Id = id;
        OrderId = orderId;
        OrderedComponent = orderedComponent;
        ComponentsCount = componentsCount;
    }
    public Guid Id { get; protected set; }
    public Guid OrderId { get; protected set; }
    /// <summary>
    /// Идентификатор заказываемой детали InventoryItem
    /// </summary>
    public Guid OrderedComponent { get; protected set; }
    public uint ComponentsCount { get; protected set; }
}