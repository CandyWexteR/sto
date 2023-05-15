using Application.CQRS;
using Core.Models.Inventory;
using Core.Repositories;

namespace Application.Inventory.Commands.Create;

public class CreateInventoryItemHandler : ICommandHandler<CreateInventoryItemCommand>
{
    private readonly IInventoryItemRepository _repos;

    public CreateInventoryItemHandler(IInventoryItemRepository repos)
    {
        _repos = repos;
    }

    public async Task Handle(CreateInventoryItemCommand request, CancellationToken cancellationToken)
    {
        var item = InventoryItem.Create(request.Id, request.Name, request.Description, request.Price, request.PriceUnits, request.Bought,
            request.BoughtUnit, request.SerialNumber);

        await _repos.AddAsync(item);
    }
}