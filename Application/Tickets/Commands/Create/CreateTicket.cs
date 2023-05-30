using Application.CQRS;

namespace Application.Tickets.Commands.Create;

public class CreateTicket : ICommand
{
    public Guid Id { get; set; }
    public Guid VehicleId { get; set; }
}