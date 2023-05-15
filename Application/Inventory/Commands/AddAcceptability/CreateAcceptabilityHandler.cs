using Application.CQRS;
using Core.Models.Inventory;
using Core.Repositories;

namespace Application.Inventory.Commands.AddAcceptability;

public class CreateAcceptabilityHandler : ICommandHandler<CreateAcceptabilityCommand>
{
    private readonly IInventoryItemRepository _repos;
    private readonly IInventoryItemAcceptabilityRepository _acceptabilityRepos;
    private readonly IVehiclesRepository _vehRepos;

    public CreateAcceptabilityHandler(IInventoryItemRepository repos, IInventoryItemAcceptabilityRepository acceptabilityRepos, IVehiclesRepository vehRepos)
    {
        _repos = repos;
        _acceptabilityRepos = acceptabilityRepos;
        _vehRepos = vehRepos;
    }

    public async Task Handle(CreateAcceptabilityCommand request, CancellationToken cancellationToken)
    {
        var acceptability =
            (await _acceptabilityRepos.GetAllAsync()).FirstOrDefault(v =>
                v.VehicleId == request.VehicleId && v.InventoryItemId == request.InventoryItemId);
        var vehicle = await _vehRepos.GetByIdAsync(request.VehicleId);
        var inventoryItem = await _repos.GetByIdAsync(request.InventoryItemId);

        if (acceptability == null && vehicle != null && inventoryItem != null)
        {
            var item = InventoryItemAcceptability.Create(request.Id, request.InventoryItemId, request.VehicleId);
            await _acceptabilityRepos.AddAsync(item);
        }
    }
}