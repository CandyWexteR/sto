using Application.PagedResult;

namespace Application.Chat.Queries;

public class MessageViewModel
{
    public Guid UserId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
}