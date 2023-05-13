using Application.Orders.InputModels;
using Application.Orders.ViewModels;

namespace Application.Orders;

public interface IOrders
{
    public Task<OrderViewModel> GetOrder(Guid id);
    public Task<OrderItemViewModel> GetOrderItem(Guid id);
    
    public Task<Guid> AddOrder(OrderInputModel model);
    public Task<Guid> AddOrderItem(OrderItemInputModel model);

    public Task ChangeOrderInfo(Guid id, OrderInputModel model);
    // public Task ChangeOrderInfo(Guid id, OrderItemInputModel model);

    public Task RemoveOrder(Guid id);
    public Task RemoveOrderItem(Guid id);
}