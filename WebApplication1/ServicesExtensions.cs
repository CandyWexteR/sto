using System.Reflection;
using Core.Repositories;
using DataAccess.Repositories;

namespace WebApplication1;

public static class ServicesExtensions
{
    public static void RegisterAbstractions(this IServiceCollection services)
    {
        //repos
        
        services.AddHttpContextAccessor();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IInventoryItemRepository, InventoryItemRepository>();
        services.AddTransient<IBugsRepository, BugsRepository>();
        services.AddTransient<IChatMessageRepository, ChatMessageRepository>();
    }
}