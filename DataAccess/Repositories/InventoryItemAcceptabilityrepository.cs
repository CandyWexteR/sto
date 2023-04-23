using Core.Models.Inventory;
using Core.Repositories;
using DataAccess.Context;

namespace DataAccess.Repositories;

public class InventoryItemAcceptabilityrepository : RepositoryBase<InventoryItemAcceptability>,
    IInventoryItemAcceptabilityRepository
{
    public InventoryItemAcceptabilityrepository(DatabaseContext context) : base(context,
        context.InventoryItemAcceptabilities)
    {
    }
}