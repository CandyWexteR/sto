using Application.Inventory.ViewModels;

namespace Application.Orders.ViewModels;

public class OrderedItem
{
    public InventoryItemShortViewModel InventoryItem { get; set; }
    public uint Count { get; set; }
}