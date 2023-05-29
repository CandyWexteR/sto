using Application.CQRS;
using Application.IdGenerator;
using Application.Inventory.ViewModels;
using Application.Orders.ViewModels;
using Application.TimeProvider;
using Core.Repositories;

namespace Application.Orders.Queries.GetSingle;

public class GetSingleHandler : IQueryHandler<GetSingle, OrderViewModel>
{
    private readonly IOrdersRepository _orders;
    private readonly IOrderItemsRepository _orderItems;
    private readonly IInventoryItemRepository _items;

    public GetSingleHandler(IOrdersRepository orders, IOrderItemsRepository orderItems, IInventoryItemRepository items)
    {
        _orders = orders;
        _orderItems = orderItems;
        _items = items;
    }

    public async Task<OrderViewModel> Handle(GetSingle request, CancellationToken cancellationToken)
    {
        var order = await _orders.GetByIdAsync(request.Id) ?? throw new Exception();
        var orderedItems = (await _orderItems.GetAllAsync())
            .Where(v => v.OrderId == order.Id)
            .ToList();
        var items = (await _items.GetAllAsync())
            .Where(v => orderedItems.Any(v => v.OrderedComponent == v.Id))
            .Select(f=>f.ToShortViewModel())
            .ToList();

        return new OrderViewModel()
        {
            OrderItems = orderedItems.Select(v=>new OrderedItemViewModel()
            {
                InventoryItem = items.First(f=>f.Id == v.OrderedComponent),
                Count = v.ComponentsCount
            }).ToList(),
            Id = order.Id,
            Description = order.Description,
            Title = order.Title,
            CreatedAt = order.CreatedAt,
            OrderDelivered = order.OrderDelivered,
            ResponsibleUserId = order.ResponsibleUserId
        };
    }
}