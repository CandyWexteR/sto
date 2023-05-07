using Newtonsoft.Json;

namespace Core.Models.Inventory;

public class InventoryItemAcceptability : IdableEntity
{
    [JsonConstructor]
    private InventoryItemAcceptability(Guid id, Guid inventoryItemId, Guid vehicleId)
    {
        Id = id;
        InventoryItemId = inventoryItemId;
        VehicleId = vehicleId;
    }
    
    public Guid Id { get; set; }
    public Guid InventoryItemId { get; set; }
    public Guid VehicleId { get; set; }

    public static InventoryItemAcceptability Create(Guid id, Guid inventoryItemId, Guid vehicleId)
    {
        return new InventoryItemAcceptability(id, inventoryItemId, vehicleId);
    }
}