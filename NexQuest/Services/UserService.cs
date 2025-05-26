using Microsoft.EntityFrameworkCore;
using NexQuest.Database;
using NexQuest.Models;
using System;
using System.Threading.Tasks;

namespace NexQuest.Services;
public class UserService(NexQuestDbContext dbContext): IUserService
{
    public readonly NexQuestDbContext dbContext = dbContext;

    public async Task AddUserAsync(string username, string password)
    {
        var newUser = new User(username, password);
        await dbContext.Users.AddAsync(newUser);
        await dbContext.SaveChangesAsync();
    }

    public async Task<User?> GetOrAddUserAsync(string username, string password)
    {
        var currentUser = await GetUserAsync(username);
        if (currentUser != null)
            return currentUser;
        var newUser = new User(username, password);
        await dbContext.Users.AddAsync(newUser);
        await dbContext.SaveChangesAsync();
        return newUser;
    }

    public async Task<User?> GetUserAsync(string username)
        => await dbContext.Users
                          .FirstOrDefaultAsync(u => u.Username == username);

    public async Task<User?> GetUserAsync(int id)
        => await dbContext.Users
                          .FirstOrDefaultAsync(u => u.ID == id);

    public async Task<User?> GetUserAsync(Guid uuid)
        => await dbContext.Users
                          .FirstOrDefaultAsync(u => u.UUID == uuid);
}
