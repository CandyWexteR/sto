using Application.CQRS;
using Core.Models.Tickets;
using Core.Repositories;

namespace Application.Tickets.Commands.Create;

public class CreateTicketHandler : ICommandHandler<CreateTicket>
{
    private readonly ITicketsRepository _tickets;

    public CreateTicketHandler(ITicketsRepository tickets)
    {
        _tickets = tickets;
    }

    public Task Handle(CreateTicket request, CancellationToken cancellationToken)
    {
        return _tickets.AddAsync(Ticket.Create(request.Id, request.VehicleId));
    }
}