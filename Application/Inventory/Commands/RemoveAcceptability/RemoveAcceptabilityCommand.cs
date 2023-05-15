using Application.CQRS;

namespace Application.Inventory.Commands.RemoveAcceptability;

public class RemoveAcceptabilityCommand : ICommand
{
    public Guid Id { get; set; }
}