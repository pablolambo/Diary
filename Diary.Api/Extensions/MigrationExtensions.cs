namespace Diary.Api.Extensions;

using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

public static class MigrationExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        using DiaryDbContext context = scope.ServiceProvider.GetRequiredService<DiaryDbContext>();
        
        context.Database.Migrate();
    }
}