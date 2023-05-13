using Application.IdGenerator;
using Application.Inventory.ViewModels;
using Application.Orders.InputModels;
using Application.Orders.ViewModels;
using Application.TimeProvider;
using Core.Models.Inventory;
using Core.Models.Orders;
using Core.Repositories;

namespace Application.Orders;

public class Orders : IOrders
{
    private readonly IOrdersRepository _orders;
    private readonly IOrderItemsRepository _orderItems;
    private readonly IInventoryItemRepository _items;
    private readonly IIdGenerator _idGenerator;
    private readonly IMarkedForRemoveOrdersRepository _ordersRemoveRepos;
    private readonly ITimeProvider _timeProvider;

    public Orders(IOrdersRepository orders, IOrderItemsRepository orderItems, IInventoryItemRepository items,
        IIdGenerator idGenerator, IMarkedForRemoveOrdersRepository ordersRemoveRepos, ITimeProvider timeProvider)
    {
        _orders = orders;
        _orderItems = orderItems;
        _items = items;
        _idGenerator = idGenerator;
        _ordersRemoveRepos = ordersRemoveRepos;
        _timeProvider = timeProvider;
    }

    public async Task<OrderViewModel> GetOrder(Guid id)
    {
        var order = await _orders.GetByIdAsync(id) ?? throw new Exception();
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

    public async Task<OrderItemViewModel> GetOrderItem(Guid id)
    {
        var item = await _orderItems.GetByIdAsync(id);
        
        return new OrderItemViewModel()
        {
            OrderId = item.OrderId,
            ComponentsCount = item.ComponentsCount,
            OrderedComponent = item.OrderedComponent,
            Id = item.Id
        };
    }

    public async Task<Guid> AddOrder(OrderInputModel model)
    {
        var id = await _idGenerator.GenerateGuidAsync();
        var order = Order.Create(id, model.Title, model.Description, model.CreatedAt, model.ResponsibleUserId);

        await _orders.AddAsync(order);
        
        return id;
    }

    public async Task<Guid> AddOrderItem(OrderItemInputModel model)
    {
        var id = await _idGenerator.GenerateGuidAsync();
        var order = new OrderItem(id, model.OrderId, model.InventoryItemId, model.Count);

        await _orderItems.AddAsync(order);

        return id;
    }

    public Task ChangeOrderInfo(Guid id, OrderInputModel model)
    {
        throw new NotImplementedException();
    }

    // public Task ChangeOrderInfo(Guid id, OrderItemInputModel model)
    // {
    //     throw new NotImplementedException();
    // }

    public async Task RemoveOrder(Guid id)
    {
        // var order = await _orders.GetByIdAsync(id) ?? throw new Exception();

        var time = await _timeProvider.GetCurrentDateTimeAsync();
        
        await _ordersRemoveRepos.AddAsync(new MarkedForRemoveOrder(id, time));
    }

    public Task RemoveOrderItem(Guid id)
    {
        return _orderItems.RemoveAsync(id);
    }
}