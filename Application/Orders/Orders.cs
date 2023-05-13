using Application.Inventory.ViewModels;
using Application.Orders.InputModels;
using Application.Orders.ViewModels;
using Core.Models.Inventory;
using Core.Repositories;

namespace Application.Orders;

public class Orders : IOrders
{
    private readonly IOrdersRepository _orders;
    private readonly IOrderItemsRepository _orderItems;
    private readonly IInventoryItemRepository _items;

    public Orders(IOrdersRepository orders, IOrderItemsRepository orderItems, IInventoryItemRepository items)
    {
        _orders = orders;
        _orderItems = orderItems;
        _items = items;
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
            OrderItems = orderedItems.Select(v=>new OrderedItem()
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

    public Task<Guid> AddOrder(OrderInputModel model)
    {
        throw new NotImplementedException();
    }

    public Task<Guid> AddOrderItem(OrderItemInputModel model)
    {
        throw new NotImplementedException();
    }

    public Task ChangeOrderInfo(Guid id, OrderInputModel model)
    {
        throw new NotImplementedException();
    }

    public Task ChangeOrderInfo(Guid id, OrderItemInputModel model)
    {
        throw new NotImplementedException();
    }

    public Task RemoveOrder(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task RemoveOrderItem(Guid id)
    {
        throw new NotImplementedException();
    }
}