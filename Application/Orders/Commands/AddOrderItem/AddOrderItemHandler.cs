using Application.CQRS;
using Core.Models.Orders;
using Core.Repositories;

namespace Application.Orders.Commands.AddOrderItem;

public class AddOrderItemHandler : ICommandHandler<AddOrderItem>
{
    private readonly IOrderItemsRepository _orderItems;

    public AddOrderItemHandler(IOrderItemsRepository orderItems)
    {
        _orderItems = orderItems;
    }

    public Task Handle(AddOrderItem request, CancellationToken cancellationToken)
    {
        var order = new OrderItem(request.Id, request.OrderId, request.InventoryItemId, request.Count);

        return _orderItems.AddAsync(order);
    }
}