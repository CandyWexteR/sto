using Core.Models.Inventory;
using Core.Repositories;
using DataAccess.Context;

namespace DataAccess.Repositories;

public class InventoryItemRepository : RepositoryBase<InventoryItem>, IInventoryItemRepository
{
    public InventoryItemRepository(DatabaseContext context) : base(context, context.InventoryItems)
    {
    }
}