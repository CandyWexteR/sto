using Application.CQRS;
using Application.PagedResult;

namespace Application.Chat.Queries;

public class GetMessages : PagedResultInputModel, IQuery<PagedResult<MessageViewModel>>
{
    public Guid TicketId { get; set; }
}