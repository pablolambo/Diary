using System.Security.Claims;
using Diary.Api.Extensions;
using Diary.Application;
using Diary.Domain.Entities;
using Diary.Domain.Interfaces;
using Diary.Domain.Services;
using Diary.Infrastructure.Persistence;
using Diary.Infrastructure.Repositories;
using Diary.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IEntryRepository, EntryRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<INotificationService, NotificationService>();

builder.Services.AddApplicationServices();
builder.Services.AddDbContext<DiaryDbContext>(options => options
    .UseSqlServer(builder.Configuration.GetConnectionString("DiaryDb")));

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme)
    .AddCookie(IdentityConstants.ApplicationScheme).AddBearerToken(IdentityConstants.BearerScheme);

builder.Services.AddIdentityCore<DiaryUserEntity>()
    .AddEntityFrameworkStores<DiaryDbContext>()
    .AddApiEndpoints();
    
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
    app.ApplyMigrations();
}

app.MapGet("users/me", async (ClaimsPrincipal claims, DiaryDbContext context) =>
{
    var userId = claims.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;

    return await context.Users.FindAsync(userId);
}).RequireAuthorization();

app.UseHttpsRedirection();
app.MapIdentityApi<DiaryUserEntity>();
app.UseAuthorization();
app.MapControllers();
app.Run();
