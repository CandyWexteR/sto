using Application.CQRS;
using Core.Extensions;
using Core.Repositories;

namespace Application.Tickets.Commands.AssignRespinsibleUser;

public class AssignResponsibleHandler : ICommandHandler<AssignResponsible>
{
    private readonly ITicketsRepository _tickets;
    private readonly IUserRepository _users;

    public AssignResponsibleHandler(ITicketsRepository tickets, IUserRepository users)
    {
        _tickets = tickets;
        _users = users;
    }

    public async Task Handle(AssignResponsible request, CancellationToken cancellationToken)
    {
        var ticket = await _tickets.GetByIdAsync(request.TicketId);
        ticket.ThrowIfNull();
        var user = await _users.GetByIdAsync(request.ResponsibleUserId);
        user.ThrowIfNull();
        
        ticket?.AssignRespinsibleUser(request.ResponsibleUserId);
        await _tickets.UpdateAsync(ticket);
    }
}