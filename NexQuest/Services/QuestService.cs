using Microsoft.EntityFrameworkCore;
using NexQuest.Database;
using NexQuest.Models;
using System;

namespace NexQuest.Services;
public class QuestService(NexQuestDbContext dbContext) : IQuestService
{
    public readonly NexQuestDbContext dbContext = dbContext;

    public async Task AddQuestAsync(string title, string description)
    {
        var newQuest = new Quest(title, description);
        await dbContext.Quests.AddAsync(newQuest);
        await dbContext.SaveChangesAsync();
    }

    public Task<Quest?> GetQuestAsync(int id)
    {
        throw new NotImplementedException();
    }
}
