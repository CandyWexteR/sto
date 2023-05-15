using Application.CQRS;
using Core.Repositories;

namespace Application.Inventory.Commands.RemoveAcceptability;

public class RemoveAcceptabilityHandler2 : ICommandHandler<RemoveAcceptabilityCommand2>
{
    private readonly IInventoryItemAcceptabilityRepository _acceptabilityRepos;

    public RemoveAcceptabilityHandler2(IInventoryItemAcceptabilityRepository acceptabilityRepos)
    {
        _acceptabilityRepos = acceptabilityRepos;
    }

    public async Task Handle(RemoveAcceptabilityCommand2 request, CancellationToken cancellationToken)
    {
        var acceptability =
            (await _acceptabilityRepos.GetAllAsync()).FirstOrDefault(v =>
                v.VehicleId == request.VehicleId && v.InventoryItemId == request.InventoryItemId) ?? throw new Exception();
        await _acceptabilityRepos.RemoveAsync(acceptability.Id);
    }
}