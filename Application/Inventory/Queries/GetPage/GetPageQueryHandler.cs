using Application.CQRS;
using Application.Inventory.ViewModels;
using Application.PagedResult;
using Core.Repositories;

namespace Application.Inventory.Queries.GetPage;

public class GetPageQueryHandler : IQueryHandler<GetPageQuery, PagedResult<InventoryItemShortViewModel>>
{
    private readonly IInventoryItemRepository _repos;

    public GetPageQueryHandler(IInventoryItemRepository repos)
    {
        _repos = repos;
    }

    public async Task<PagedResult<InventoryItemShortViewModel>> Handle(GetPageQuery request, CancellationToken cancellationToken)
    {
        var all = await _repos.GetAllAsync();

        return all.Select(v => new InventoryItemShortViewModel()
            {
                Id = v.Id,
                Name = v.Name
            })
            .ToPagedResult(request.Input);
    }
}