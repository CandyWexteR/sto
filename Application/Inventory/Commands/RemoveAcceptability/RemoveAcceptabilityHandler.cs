using Application.CQRS;
using Core.Repositories;

namespace Application.Inventory.Commands.RemoveAcceptability;

public class RemoveAcceptabilityHandler : ICommandHandler<RemoveAcceptabilityCommand>
{
    private readonly IInventoryItemAcceptabilityRepository _acceptabilityRepos;

    public RemoveAcceptabilityHandler(IInventoryItemAcceptabilityRepository acceptabilityRepos)
    {
        _acceptabilityRepos = acceptabilityRepos;
    }

    public Task Handle(RemoveAcceptabilityCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}