using Application.CQRS;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Application.Inventory.Commands.AddAcceptability;

public class CreateAcceptabilityCommand : ICommand
{
    public Guid Id { get; set; }
    public Guid VehicleId { get; set; }
    public Guid InventoryItemId { get; set; }
}