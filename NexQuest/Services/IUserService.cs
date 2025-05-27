using NexQuest.Models;

namespace NexQuest.Services;
public interface IUserService
{
    Task AddUserAsync(string username, string password);

    Task<User?> GetOrAddUserAsync(string username, string password);

    Task<User?> GetUserAsync(string username);

    Task<User?> GetUserAsync(int id);

    Task<User?> GetUserAsync(Guid uuid);

}
