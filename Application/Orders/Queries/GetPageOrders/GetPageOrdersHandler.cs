using Application.CQRS;
using Application.Orders.ViewModels;
using Application.PagedResult;

namespace Application.Orders.Queries.GetPageOrders;

public class GetPageOrdersHandler : IQueryHandler<GetPageOrders, PagedResult<OrderViewModel>>
{
    public Task<PagedResult<OrderViewModel>> Handle(GetPageOrders request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}