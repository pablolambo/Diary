## Setup database
### Pull docker image for mysql
```bash
docker pull mcr.microsoft.com/mssql/server:2022-latest
```
### Run database as docker container
```bash
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=YourStrong!Password' -p 1433:1433 --name DiaryDb -d mcr.microsoft.com/mssql/server:2022-latest
```
## Database migrations
### Create migration
```bash
dotnet ef migrations add InitialCreate --project "C:\Users\pawel\Diary\Diary.Infrastructure\Diary.Infrastructure.csproj" --startup-project "C:\Users\pawel\Diary\Diary.Api\Diary.Api.csproj"
```
### Update db
```bash
 dotnet ef database update --project "C:\Users\pawel\Diary\Diary.Infrastructure\Diary.Infrastructure.csproj" --startup-project "C:\Users\pawel\Diary\Diary.Api\Diary.Api.csproj"
```