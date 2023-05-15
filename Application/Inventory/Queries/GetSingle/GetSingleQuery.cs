using Application.CQRS;
using Application.Inventory.ViewModels;

namespace Application.Inventory.Queries.GetSingle;

public class GetSingleQuery : IQuery<InventoryItemFullViewModel>
{
    public Guid Id { get; set; }
}