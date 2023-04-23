using Core.Models.Chat;
using Core.Repositories;
using DataAccess.Context;

namespace DataAccess.Repositories;

public class ChatMessageRepository : RepositoryBase<ChatMessage>, IChatMessageRepository
{
    public ChatMessageRepository(DatabaseContext context) : base(context, context.Messages)
    {
    }
}