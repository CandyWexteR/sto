using Application.CQRS;

namespace Application.Inventory.Commands.RemoveInventoryItem;

public class RemoveInventoryItemCommand : ICommand
{
    public Guid Id { get; set; }
}