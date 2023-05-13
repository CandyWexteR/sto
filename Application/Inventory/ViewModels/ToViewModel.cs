using Core.Models.Inventory;

namespace Application.Inventory.ViewModels;

public static class ToViewModel
{
    public static InventoryItemShortViewModel ToShortViewModel(this InventoryItem item) => new InventoryItemShortViewModel()
    {
        Id = item.Id,
        Name = item.Name
    };
}