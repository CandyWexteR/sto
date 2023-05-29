using Application.CQRS;
using Application.Orders.ViewModels;
using Core.Repositories;

namespace Application.Orders.Queries.GetOrderItem;

public class GetOrderItemHandler : IQueryHandler<GetOrderItem,OrderItemViewModel>
{
    private readonly IOrderItemsRepository _orderItems;

    public GetOrderItemHandler(IOrderItemsRepository orderItems)
    {
        _orderItems = orderItems;
    }

    public async Task<OrderItemViewModel> Handle(GetOrderItem request, CancellationToken cancellationToken)
    {
        var item = await _orderItems.GetByIdAsync(request.Id);
        
        return new OrderItemViewModel()
        {
            OrderId = item.OrderId,
            ComponentsCount = item.ComponentsCount,
            OrderedComponent = item.OrderedComponent,
            Id = item.Id
        };
    }
}