namespace Application.Orders.ViewModels;

public class OrderItemViewModel
{
    public Guid Id { get;  set; }
    public Guid OrderId { get;  set; }
    /// <summary>
    /// Идентификатор заказываемой детали InventoryItem
    /// </summary>
    public Guid OrderedComponent { get;  set; }
    public uint ComponentsCount { get;  set; }
}