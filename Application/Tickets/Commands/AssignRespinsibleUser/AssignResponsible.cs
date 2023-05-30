using Application.CQRS;

namespace Application.Tickets.Commands.AssignRespinsibleUser;

public class AssignResponsible : ICommand
{
    public Guid TicketId { get; set; }
    public Guid ResponsibleUserId { get; set; }
}