using Application.Inventory.ViewModels;

namespace Application.Orders.ViewModels;

public class OrderedItemViewModel
{
    public InventoryItemShortViewModel InventoryItem { get; set; }
    public uint Count { get; set; }
}