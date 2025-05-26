using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Windows;
using NexQuest.Database;

namespace NexQuestGui;
public partial class App : Application
{
    public static IHost? AppHost { get; private set; }

    protected override void OnStartup(StartupEventArgs e)
    {
        AppHost = Host.CreateDefaultBuilder()
             .ConfigureAppConfiguration((context, config) =>
             {
                 var path = Directory.GetCurrentDirectory();
                 config.SetBasePath(path);
                 config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
             })
            .ConfigureServices((context, services) =>
            {
                ConfigureServices(context.Configuration, services);
            })
            .Build();

        AppHost.Start();

        base.OnStartup(e);
    }

    private void ConfigureServices(IConfiguration configuration, IServiceCollection services)
    {
        services.AddDbContext<NexQuestDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Default")));
             
    }
}
