namespace Core.Models.Inventory;

public class InventoryItemAcceptability : IdableEntity
{
    public Guid Id { get; set; }
    public Guid InventoryItemId { get; set; }
    public Guid VehicleId { get; set; }
}