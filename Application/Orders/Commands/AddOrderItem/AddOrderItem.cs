using Application.CQRS;
using Application.Orders.InputModels;

namespace Application.Orders.Commands.AddOrderItem;

public class AddOrderItem : OrderItemInputModel, ICommand
{
    public Guid Id { get; set; }
}