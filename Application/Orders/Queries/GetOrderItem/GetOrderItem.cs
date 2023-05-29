using Application.CQRS;
using Application.Orders.ViewModels;

namespace Application.Orders.Queries.GetOrderItem;

public class GetOrderItem : IQuery<OrderItemViewModel>
{
    public Guid Id { get; set; }
}