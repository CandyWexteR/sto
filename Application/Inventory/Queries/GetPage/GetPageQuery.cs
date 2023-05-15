using Application.CQRS;
using Application.Inventory.ViewModels;
using Application.PagedResult;

namespace Application.Inventory.Queries.GetPage;

public class GetPageQuery: IQuery<PagedResult<InventoryItemShortViewModel>>
{
    public PagedResultInputModel Input { get; set; }
}