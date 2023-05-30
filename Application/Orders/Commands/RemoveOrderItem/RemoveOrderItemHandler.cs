using Application.CQRS;
using Core.Repositories;

namespace Application.Orders.Commands.RemoveOrderItem;

public class RemoveOrderItemHandler : ICommandHandler<RemoveOrder.RemoveOrder>
{
    private readonly IOrderItemsRepository _orderItems;

    public RemoveOrderItemHandler(IOrderItemsRepository orderItems)
    {
        _orderItems = orderItems;
    }

    public Task Handle(RemoveOrder.RemoveOrder request, CancellationToken cancellationToken)
    {
        return _orderItems.RemoveAsync(request.Id);
    }
}