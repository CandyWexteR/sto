using System.Reflection;
using Application.CQRS;
using Application.IdGenerator;
using Application.Jobs;
using Application.Users.Commands.CreateUser;
using Application.Users.Commands.UpdateUserToken;
using Application.Users.Queries.GetSingle;
using Core.Encryption;
using Core.Models.Users;
using Core.Repositories;
using DataAccess.Context;
using DataAccess.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Quartz;
using WebApplication1.Additonal;

namespace WebApplication1;

public static class ServicesExtensions
{
    public static void RegisterAbstractions(this IServiceCollection services, IConfiguration configuration)
    {
        //repos

        services.AddHttpContextAccessor();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.RegisterHandlers();
        services.AddQuartz(v =>
        {
            v.SchedulerId = Guid.NewGuid().ToString();
            v.UseDefaultThreadPool();
            v.UseMicrosoftDependencyInjectionJobFactory();
            v.SchedulerName = "sadasd";
            v.MaxBatchSize = 1;
            v.MaxBatchSize = 1;

            v.ScheduleJob<MigrateJob>(t => t.StartNow());
            v.ScheduleJob<OrderRemoverJob>(t =>
                t.WithSimpleSchedule(builder => builder.WithInterval(TimeSpan.FromSeconds(10)))
                    .StartAt(DateTimeOffset.Now.AddSeconds(30)));

        });
        services.AddQuartzServer(options => { options.WaitForJobsToComplete = true; });

        services.AddDbContext<DatabaseContext>(v => v.UseNpgsql(configuration["ConnectionString"]));
        services.AddTransient<IEncrypter, Crypter>();
        services.AddTransient<IDecrypter, Crypter>();
        services.AddTransient<IIdGenerator, IdGenerator>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IInventoryItemRepository, InventoryItemRepository>();
        services.AddTransient<IBugsRepository, BugsRepository>();
        services.AddTransient<IChatMessageRepository, ChatMessageRepository>();
    }

    public static void RegisterHandlers(this IServiceCollection services)
    {
        //Commands
        // services.AddSingleton<ICommandHandler<CreateUser>, CreateUserHandler>();
        services.AddScoped<IRequestHandler<CreateUser>, CreateUserHandler>();
        services.AddScoped<IRequestHandler<UpdateUserToken>, UpdateUserTokenHandler>();

        //Queries
        services.AddScoped<IRequestHandler<GetUserViaLoginPassword, User>, GetUserViaLoginPasswordHandler>();
        services.AddScoped<IRequestHandler<GetSingleUserViaToken, UserViewModel>, GetSingleUserViaTokenHandler>();
    }
}