using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace NexQuest.Database
{
    public class NexQuestDbContextFactory : IDesignTimeDbContextFactory<NexQuestDbContext>
    {
        public NexQuestDbContext CreateDbContext(string[] args)
        {
            var current = Directory.GetCurrentDirectory();
            
            var parent = Directory.GetParent(current)?.ToString();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(parent)
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<NexQuestDbContext>();
            var connectionString = configuration.GetConnectionString("Default");

            optionsBuilder.UseSqlServer(connectionString);

            return new NexQuestDbContext(optionsBuilder.Options);
        }
    }
}
