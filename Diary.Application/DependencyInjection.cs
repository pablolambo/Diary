namespace Diary.Application;

using System.Reflection;
using Handlers;
using Handlers.Entries;
using Handlers.Notifications;
using Microsoft.Extensions.DependencyInjection;
using Queries;

public static class DependencyInjection
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg
            .RegisterServicesFromAssembly(Assembly.GetAssembly(typeof(CreateEntryCommandHandler))));
        services.AddMediatR(cfg => cfg
            .RegisterServicesFromAssembly(Assembly.GetAssembly(typeof(DeleteEntryCommandHandler))));
        services.AddMediatR(cfg => cfg
            .RegisterServicesFromAssembly(Assembly.GetAssembly(typeof(UpdateEntryCommandHandler))));
        services.AddMediatR(cfg => cfg
            .RegisterServicesFromAssembly(Assembly.GetAssembly(typeof(GetEntryByIdQueryHandler))));
        services.AddMediatR(cfg => cfg
            .RegisterServicesFromAssembly(Assembly.GetAssembly(typeof(GetEntriesQueryHandler))));
        
        services.AddMediatR(cfg => cfg
            .RegisterServicesFromAssembly(Assembly.GetAssembly(typeof(GetUserStatisticsQueryHandler))));
        services.AddMediatR(cfg => cfg
            .RegisterServicesFromAssembly(Assembly.GetAssembly(typeof(CreateAndSendNotificationsCommandHandler))));
    }
}