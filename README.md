## Setup database
## Run database as docker container
```bash
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=mystrongpWD!" -p 1433:1433 --name DiaryDb -d mcr.microsoft.com/mssql/server:2022-latest
```

## Database migrations
### Create migration
```bash
dotnet ef migrations add InitialCreate --project "{PATH}\Diary\Diary.Infrastructure\Diary.Infrastructure.csproj" --startup-project "{PATH}\Diary\Diary.Api\Diary.Api.csproj"
```

### Update db
```bash
 dotnet ef database update --project "{PATH}\Diary\Diary.Infrastructure\Diary.Infrastructure.csproj" --startup-project "{PATH}\Diary\Diary.Api\Diary.Api.csproj"
```

```bash
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=mystrongpWD!" -p 1444:1433 --name DiaryDb -d mcr.microsoft.com/mssql/server:2022-latest 
```

```bash
dotnet ef migrations add InitialCreate --project "C:\Users\pawel\Diary\Diary.Infrastructure\Diary.Infrastructure.csproj" --startup-project "C:\Users\pawel\Diary\Diary.Api\Diary.Api.csproj"
```

```bash
dotnet ef database update --project "C:\Users\pawel\Diary\Diary.Infrastructure\Diary.Infrastructure.csproj" --startup-project "C:\Users\pawel\Diary\Diary.Api\Diary.Api.csproj"
```

Remember to change appsettings.json to match connstr.