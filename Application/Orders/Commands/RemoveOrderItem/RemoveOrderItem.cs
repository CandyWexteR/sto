using Application.CQRS;

namespace Application.Orders.Commands.RemoveOrderItem;

public class RemoveOrderItem : ICommand
{
    public Guid Id { get; set; }
}