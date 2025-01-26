namespace Diary.Application;

using System.Reflection;
using Handlers.Entries;
using Handlers.Themes;
using Microsoft.Extensions.DependencyInjection;
using Queries;

public static class DependencyInjection
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg
            .RegisterServicesFromAssembly(Assembly.GetAssembly(typeof(CreateEntryCommandHandler))!));
        services.AddMediatR(cfg => cfg
            .RegisterServicesFromAssembly(Assembly.GetAssembly(typeof(DeleteEntryCommandHandler))!));
        services.AddMediatR(cfg => cfg
            .RegisterServicesFromAssembly(Assembly.GetAssembly(typeof(UpdateEntryCommandHandler))!));
        services.AddMediatR(cfg => cfg
            .RegisterServicesFromAssembly(Assembly.GetAssembly(typeof(GetEntryByIdQueryHandler))!));
        services.AddMediatR(cfg => cfg
            .RegisterServicesFromAssembly(Assembly.GetAssembly(typeof(GetEntriesQueryHandler))!));
        
        services.AddMediatR(cfg => cfg
            .RegisterServicesFromAssembly(Assembly.GetAssembly(typeof(GetUserStatisticsQueryHandler))!));
        
        services.AddMediatR(cfg => cfg
            .RegisterServicesFromAssembly(Assembly.GetAssembly(typeof(GetBadgesQueryHandler))!));
        services.AddMediatR(cfg => cfg
            .RegisterServicesFromAssembly(Assembly.GetAssembly(typeof(GetThemesQueryHandler))!));
        services.AddMediatR(cfg => cfg
            .RegisterServicesFromAssembly(Assembly.GetAssembly(typeof(BuyThemeCommandHandler))!));
    }
}