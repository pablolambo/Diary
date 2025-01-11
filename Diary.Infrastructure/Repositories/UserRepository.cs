namespace Diary.Infrastructure.Repositories;

using Domain.Interfaces;
using Persistence;

public class UserRepository : IUserRepository
{
    private readonly DiaryDbContext _dbContext;

    public UserRepository(DiaryDbContext dbContext)
    {
        _dbContext = dbContext;
    }
}