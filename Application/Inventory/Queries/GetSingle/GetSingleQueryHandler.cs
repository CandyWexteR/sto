using Application.CQRS;
using Application.Inventory.ViewModels;
using Application.PagedResult;
using Core.Models.Inventory;
using Core.Repositories;

namespace Application.Inventory.Queries.GetSingle;

public class GetSingleQueryHandler : IQueryHandler<GetSingleQuery, InventoryItemFullViewModel>
{
    private readonly IInventoryItemRepository _repos;

    public GetSingleQueryHandler(IInventoryItemRepository repos)
    {
        _repos = repos;
    }

    public async Task<InventoryItemFullViewModel> Handle(GetSingleQuery request, CancellationToken cancellationToken)
    {
        var item = await _repos.GetByIdAsync(request.Id) ?? throw new Exception();
        
        return new InventoryItemFullViewModel()
        {
            Id = item.Id,
            Name = item.Name,
            Bought = item.Bought,
            Description = item.Description,
            BoughtUnit = item.BoughtUnit,
            PriceUnits = item.PriceUnits,
            SerialNumber = item.SerialNumber,
            Price = item.Price
        };
    }
}