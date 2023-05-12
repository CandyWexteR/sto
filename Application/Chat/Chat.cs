using Application.Bugs;
using Application.Chat.InputModels;
using Application.IdGenerator;
using Application.TimeProvider;
using Core.AuthorizationProvider;
using Core.Models.Chat;
using Core.Repositories;

namespace Application.Chat;

public class Chats: IChats
{
    private readonly IChatMessageRepository _repos;
    private readonly IAuthProvider _authProvider;
    private readonly IIdGenerator _generator;
    private readonly ITimeProvider _timeProvider;

    public Chats(IChatMessageRepository repos, IAuthProvider authProvider, IIdGenerator generator, 
        ITimeProvider timeProvider)
    {
        _repos = repos;
        _authProvider = authProvider;
        _generator = generator;
        _timeProvider = timeProvider;
    }

    public async Task<Guid> SendMessage(MessageInputModel model)
    {
        var id = await _generator.GenerateGuidAsync();
        
        var user = await _authProvider.GetUser();
        
        var dateTimeProvider = await _timeProvider.GetCurrentDateTimeAsync();
        
        var msg = ChatMessage.Create(id, model.Message, dateTimeProvider, user.Id, model.TicketId);

        await _repos.AddAsync(msg);
        
        return id;
    }
}