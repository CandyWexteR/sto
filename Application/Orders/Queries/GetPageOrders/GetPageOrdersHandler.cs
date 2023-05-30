using Application.CQRS;
using Application.Orders.ViewModels;
using Application.PagedResult;
using Core.Repositories;

namespace Application.Orders.Queries.GetPageOrders;

public class GetPageOrdersHandler : IQueryHandler<GetPageOrders, PagedResult<OrderViewModel>>
{
    private readonly IOrdersRepository _orders;

    public GetPageOrdersHandler(IOrdersRepository orders)
    {
        _orders = orders;
    }

    public async Task<PagedResult<OrderViewModel>> Handle(GetPageOrders request, CancellationToken cancellationToken)
    {
        var all = await _orders.GetAllAsync();
        return all.Select(order => new OrderViewModel()
        {
            Id = order.Id,
            Description = order.Description,
            Title = order.Title,
            CreatedAt = order.CreatedAt,
            OrderDelivered = order.OrderDelivered,
            ResponsibleUserId = order.ResponsibleUserId,
            OrderItems = new List<OrderedItemViewModel>()
        })
            .ToPagedResult(request);
    }
}