using Application.Orders.InputModels;
using Application.Orders.ViewModels;

namespace Application.Orders;

public class Orders : IOrders
{
    public Task<OrderViewModel> GetOrder()
    {
        throw new NotImplementedException();
    }

    public Task<OrderItemViewModel> GetOrderItem()
    {
        throw new NotImplementedException();
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