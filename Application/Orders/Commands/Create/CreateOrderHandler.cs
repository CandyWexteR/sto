using Application.CQRS;
using Core.Models.Orders;
using Core.Repositories;

namespace Application.Orders.Commands.Create;

public class CreateOrderHandler : ICommandHandler<CreateOrder>
{
    private readonly IOrdersRepository _orders;

    public CreateOrderHandler(IOrdersRepository orders)
    {
        _orders = orders;
    }

    public Task Handle(CreateOrder request, CancellationToken cancellationToken)
    {
        var order = Order.Create(request.Id, request.Title, request.Description, request.CreatedAt,
            request.ResponsibleUserId);

        return _orders.AddAsync(order);
    }
}