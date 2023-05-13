using Application.CQRS;
using Application.TimeProvider;
using Core.AuthorizationProvider;
using Core.Models.Chat;
using Core.Repositories;

namespace Application.Chat.Commands;

public class SendMessageHandler : ICommandHandler<SendMessage>
{
    private readonly IChatMessageRepository _repos;
    private readonly IAuthProvider _authProvider;
    private readonly ITimeProvider _timeProvider;

    public SendMessageHandler(IChatMessageRepository repos, IAuthProvider authProvider, ITimeProvider timeProvider)
    {
        _repos = repos;
        _authProvider = authProvider;
        _timeProvider = timeProvider;
    }

    public async Task Handle(SendMessage request, CancellationToken cancellationToken)
    {
        var user = await _authProvider.GetUser();
        
        var dateTimeProvider = await _timeProvider.GetCurrentDateTimeAsync();
        
        var msg = ChatMessage.Create(request.Id, request.Message, dateTimeProvider, user.Id, request.TicketId);

        await _repos.AddAsync(msg);
    }
}