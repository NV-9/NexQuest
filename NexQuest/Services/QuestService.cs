using Microsoft.EntityFrameworkCore;
using NexQuest.Database;
using NexQuest.Models;

namespace NexQuest.Services;
public class QuestService(NexQuestDbContext dbContext) : IQuestService
{
    public readonly NexQuestDbContext _dbContext = dbContext;

    public async Task AddQuestAsync(string title, string description)
    {
        var newQuest = new Quest(title, description);
        await _dbContext.Quests.AddAsync(newQuest);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Quest>> GetAllQuestsAsync()
        => await _dbContext.Quests.ToListAsync();

}
