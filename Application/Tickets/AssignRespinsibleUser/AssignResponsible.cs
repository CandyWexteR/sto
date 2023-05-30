using Application.CQRS;

namespace Application.Tickets.AssignRespinsibleUser;

public class AssignResponsible : ICommand
{
    public Guid TicketId { get; set; }
    public Guid ResponsibleUserId { get; set; }
}