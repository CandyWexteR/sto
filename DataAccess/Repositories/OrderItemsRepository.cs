using Core.Models.Orders;
using Core.Repositories;
using DataAccess.Context;

namespace DataAccess.Repositories;

public class OrderItemsRepository : RepositoryBase<OrderItem>, IOrderItemsRepository
{
    public OrderItemsRepository(DatabaseContext context) : base(context, context.OrderItems)
    {
    }
}