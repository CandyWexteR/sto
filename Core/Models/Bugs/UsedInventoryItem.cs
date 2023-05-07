using Newtonsoft.Json;

namespace Core.Models.Bugs;

public class UsedInventoryItem
{
    [JsonConstructor]
    private UsedInventoryItem(Guid id, Guid inventoryItemId, Guid bugId)
    {
        Id = id;
        InventoryItemId = inventoryItemId;
        BugId = bugId;
    }
    public Guid Id { get; set; }
    public Guid InventoryItemId { get; set; }
    public Guid BugId { get; set; }

    public static UsedInventoryItem Create(Guid id, Guid inventoryItemId, Guid bugId)
    {
        return new UsedInventoryItem(id, inventoryItemId, bugId);
    }
}