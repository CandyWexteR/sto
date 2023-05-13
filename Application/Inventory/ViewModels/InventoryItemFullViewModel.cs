namespace Application.Inventory.ViewModels;

public class InventoryItemFullViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string SerialNumber { get; set; }
    public ulong Price { get; set; }
    public string PriceUnits { get; set; }
    public ulong Bought { get; set; }
    public string BoughtUnit { get; set; }
}