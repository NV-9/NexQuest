using Microsoft.EntityFrameworkCore;
using NexQuest.Models;
using System.Reflection;

namespace NexQuest.Database;
public class NexQuestDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<Quest> Quests { get; set; }

    public NexQuestDbContext(DbContextOptions<NexQuestDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}

