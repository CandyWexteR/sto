using Application.Bugs;
using Core.Repositories;

namespace Application.Chat;

public class Chats: IChats
{
    private readonly IChatMessageRepository _repos;

    public Chats(IChatMessageRepository repos)
    {
        _repos = repos;
    }

    public Task<Guid> SendMessage()
    {
        throw new NotImplementedException();
    }
}