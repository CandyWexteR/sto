namespace Application.Orders.InputModels;

public class OrderItemInputModel
{
    public Guid OrderId { get; set; }
    public Guid InventoryItemId { get; set; }
    public int Count { get; set; }
}