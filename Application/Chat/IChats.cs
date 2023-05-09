namespace Application.Chat;

public interface IChats
{
    public Task<Guid> SendMessage();
}