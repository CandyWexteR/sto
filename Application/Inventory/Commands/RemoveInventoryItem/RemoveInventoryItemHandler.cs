using Application.CQRS;
using Core.Repositories;

namespace Application.Inventory.Commands.RemoveInventoryItem;

public class RemoveInventoryItemHandler: ICommandHandler<RemoveInventoryItemCommand>
{
    private readonly IInventoryItemRepository _repos;

    public RemoveInventoryItemHandler(IInventoryItemRepository repos)
    {
        _repos = repos;
    }

    public Task Handle(RemoveInventoryItemCommand request, CancellationToken cancellationToken) => 
        _repos.RemoveAsync(request.Id);
}