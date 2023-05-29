using Application.CQRS;
using Application.Orders.ViewModels;
using Application.PagedResult;
using Core.Models.Orders;

namespace Application.Orders.Queries.GetPageOrders;

public class GetPageOrders : PagedResultInputModel, IQuery<PagedResult<OrderViewModel>>
{
    
}