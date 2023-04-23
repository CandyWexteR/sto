using Core.Models.Orders;
using Core.Repositories;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class OrdersRepository : RepositoryBase<Order>, IOrdersRepository
{
    public OrdersRepository(DatabaseContext context) : base(context, context.Orders)
    {
    }
}