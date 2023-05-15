using Application.CQRS;

namespace Application.Inventory.Commands.RemoveAcceptability;

public class RemoveAcceptabilityCommand2 : ICommand
{
    public Guid VehicleId { get; set; }
    public Guid InventoryItemId { get; set; }
}