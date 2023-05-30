using Application.CQRS;
using Core.Models.Tickets;

namespace Application.Tickets.UpdateInfo;

public class UpdateTicket : ICommand
{
    public Guid TicketId { get; set; }
    public Guid VehicleId { get; set; }
    public TicketState State { get; set; }
    public ulong Cost { get; set; }
}