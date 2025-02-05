using System.Text.Json.Serialization;
using Diary.Api.Extensions;
using Diary.Api.Filters;
using Diary.Application;
using Diary.Domain.Entities;
using Diary.Domain.Interfaces;
using Diary.Infrastructure.Persistence;
using Diary.Infrastructure.Repositories;
using Diary.Infrastructure.Services;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IEntryRepository, EntryRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBadgeRepository, BadgeRepository>();
builder.Services.AddScoped<ITagsRepository, TagsRepository>();
builder.Services.AddScoped<INotificationService, FirebaseNotificationService>();

builder.Services.AddApplicationServices();
builder.Services.AddDbContext<DiaryDbContext>(options => options
    .UseSqlServer(builder.Configuration.GetConnectionString("DiaryDb")));

builder.Services.AddAuthentication(IdentityConstants.BearerScheme)
    .AddCookie(IdentityConstants.ApplicationScheme).AddBearerToken(IdentityConstants.BearerScheme);

builder.Services.AddAuthorization();

builder.Services.AddIdentityCore<DiaryUserEntity>()
    .AddEntityFrameworkStores<DiaryDbContext>()
    .AddApiEndpoints();
    
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("DiaryApi_v1", new OpenApiInfo { Title = "DiaryApi", Version = "v1" });
    c.AddSecurityDefinition("token", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        In = ParameterLocation.Header,
        Name = HeaderNames.Authorization,
        Scheme = "Bearer"
    });

    c.OperationFilter<SecureEndpointAuthRequirementFilter>();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/DiaryApi_v1/swagger.json", "DiaryApi v1");
    });
    
    app.ApplyMigrations();
}

FirebaseApp.Create(new AppOptions
{
    Credential = GoogleCredential.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "diaryfcm-329ad-firebase-adminsdk-fbsvc-5d23ab4a7a.json")),
});

app.UseHttpsRedirection();
app.MapIdentityApi<DiaryUserEntity>();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
