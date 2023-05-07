using Core.Models.Bugs;
using Core.Repositories;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class UsedInventoryItemsRepository : RepositoryBase<UsedInventoryItem>, IUsedInventoryItemRepository
{
    public UsedInventoryItemsRepository(DatabaseContext context) : base(context, context.UsedInventoryItems)
    {
    }
}