
using NexQuest.Models;

namespace NexQuest.Services;
public interface IQuestService
{
    Task AddQuestAsync(string title, string description);

    Task<Quest?> GetQuestAsync(int id);

}
