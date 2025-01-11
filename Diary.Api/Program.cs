using System.Security.Claims;
using Diary.Api.Extensions;
using Diary.Application;
using Diary.Domain.Entities;
using Diary.Domain.Interfaces;
using Diary.Infrastructure.Persistence;
using Diary.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IEntryRepository, EntryRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddApplicationServices();
builder.Services.AddDbContext<DiaryDbContext>(options => options
    .UseSqlServer(builder.Configuration.GetConnectionString("DiaryDb")));

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme)
    .AddCookie(IdentityConstants.ApplicationScheme).AddBearerToken(IdentityConstants.BearerScheme);

builder.Services.AddIdentityCore<DiaryUser>()
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
    string userId = claims.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;

    return await context.Users.FindAsync(userId);
}).RequireAuthorization();

app.UseHttpsRedirection();
app.MapIdentityApi<DiaryUser>();
app.UseAuthorization();
app.MapControllers();
app.Run();
