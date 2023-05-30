using Application.CQRS;
using Core.Repositories;

namespace Application.Inventory.Commands.ChangeInfo;

public class ChangeInventoryItemInfoHandler : ICommandHandler<ChangeInventoryItemInfoCommand>
{
    private readonly IInventoryItemRepository _repos;

    public ChangeInventoryItemInfoHandler(IInventoryItemRepository repos)
    {
        _repos = repos;
    }

    public async Task Handle(ChangeInventoryItemInfoCommand request, CancellationToken cancellationToken)
    {
        var item = await _repos.GetByIdAsync(request.Id) ?? throw new Exception("");

        item.ChangeInfo(request.Name, request.Description, request.Price, request.PriceUnits, request.Bought,
            request.BoughtUnit, request.SerialNumber);

        await _repos.UpdateAsync(item);
    }
}