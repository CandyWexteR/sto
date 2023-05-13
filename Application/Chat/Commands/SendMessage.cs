using Application.CQRS;

namespace Application.Chat.Commands;

public class SendMessage : ICommand
{
    public Guid Id { get; set; }
    public string Message { get; set; }
    public Guid TicketId { get; set; }
}