using Core.Models.Orders;
using Core.Repositories;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class MarkedForRemoveOrdersRepository : RepositoryBase<MarkedForRemoveOrder>, IMarkedForRemoveOrdersRepository
{
    public MarkedForRemoveOrdersRepository(DatabaseContext context) : base(context, context.MarkedForRemoveOrders)
    {
    }
}