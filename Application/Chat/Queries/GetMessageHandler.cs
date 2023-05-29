using Application.CQRS;
using Application.PagedResult;
using Core.Repositories;

namespace Application.Chat.Queries;

public class GetMessageHandler : IQueryHandler<GetMessages, PagedResult<MessageViewModel>>
{
    private readonly IChatMessageRepository _repos;

    public GetMessageHandler(IChatMessageRepository repos)
    {
        _repos = repos;
    }

    public async Task<PagedResult<MessageViewModel>> Handle(GetMessages request, CancellationToken cancellationToken)
    {
        var allMessages = await _repos.GetAllAsync();

        var ticketMessages = allMessages.Where(v => v.TicketId == request.TicketId);

        return ticketMessages
            .Select(v => new MessageViewModel()
            {
                Content = v.Message,
                CreatedAt = v.CreatedAt,
                UserId = v.AuthorId
            })
            .ToPagedResult(request);
    }
}