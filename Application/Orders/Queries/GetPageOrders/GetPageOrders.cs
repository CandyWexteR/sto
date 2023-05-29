using Application.CQRS;
using Application.PagedResult;
using Core.Models.Orders;

namespace Application.Orders.Queries.GetPageOrders;

public class GetPageOrders : IQuery<PagedResult<Order>>
{
    
}