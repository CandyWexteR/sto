using Application.Chat.InputModels;

namespace Application.Chat;

public interface IChats
{
    public Task<Guid> SendMessage(MessageInputModel model);
}