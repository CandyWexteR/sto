using Application.CQRS;

namespace Application.Orders.Commands.RemoveOrder;

public class RemoveOrder : ICommand
{
    public Guid Id { get; set; }
}