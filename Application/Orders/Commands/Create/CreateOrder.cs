using Application.CQRS;
using Application.Orders.InputModels;

namespace Application.Orders.Commands.Create;

public class CreateOrder : OrderInputModel, ICommand
{
    public Guid Id { get; set; }
}