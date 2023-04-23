using Core.Repositories;
using DataAccess.Repositories;

namespace WebApi;

public static class ServicesExtensions
{
    public static void RegisterAbstractions(this IServiceCollection services)
    {
        //repos
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IInventoryItemRepository, InventoryItemRepository>();
        services.AddTransient<IBugsRepository, BugsRepository>();
        services.AddTransient<IChatMessageRepository, ChatMessageRepository>();
    }
}