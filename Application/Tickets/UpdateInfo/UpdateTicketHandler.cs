using Application.CQRS;
using Core.Extensions;
using Core.Repositories;

namespace Application.Tickets.UpdateInfo;

public class UpdateTicketHandler : ICommandHandler<UpdateTicket>
{
    private readonly ITicketsRepository _tickets;

    public UpdateTicketHandler(ITicketsRepository tickets)
    {
        _tickets = tickets;
    }

    public async Task Handle(UpdateTicket request, CancellationToken cancellationToken)
    {
        var ticket = await _tickets.GetByIdAsync(request.TicketId);
        ticket.ThrowIfNull();
        ticket?.UpdateInfo(request.VehicleId, request.State, request.Cost);
        await _tickets.UpdateAsync(ticket);
    }
}