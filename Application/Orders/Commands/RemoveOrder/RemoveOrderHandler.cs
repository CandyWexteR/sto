using Application.CQRS;
using Application.TimeProvider;
using Core.Models.Orders;
using Core.Repositories;

namespace Application.Orders.Commands.RemoveOrder;

public class RemoveOrderHandler : ICommandHandler<RemoveOrder>
{
    private readonly IMarkedForRemoveOrdersRepository _ordersRemoveRepos;
    private readonly ITimeProvider _timeProvider;

    public RemoveOrderHandler(IMarkedForRemoveOrdersRepository ordersRemoveRepos, ITimeProvider timeProvider)
    {
        _ordersRemoveRepos = ordersRemoveRepos;
        _timeProvider = timeProvider;
    }

    public Task Handle(RemoveOrder request, CancellationToken cancellationToken)
    {
        var time = _timeProvider.GetCurrentDateTime();
        return _ordersRemoveRepos.AddAsync(new MarkedForRemoveOrder(request.Id, time));
    }
}