using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Windows;
using NexQuest.Database;
using NexQuest.Services;
using NexQuestGui.Views;
using System.Windows.Navigation;
using NexQuestGui.ViewModels;
using System.Windows.Controls;

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

        var mainWindow = AppHost.Services.GetRequiredService<MainWindow>();
        var dashboard = AppHost.Services.GetRequiredService<Dashboard>();
        mainWindow.MainFrame.Navigate(dashboard);
        mainWindow.Show();

        base.OnStartup(e);
    }

    private void ConfigureServices(IConfiguration configuration, IServiceCollection services)
    {
        services.AddDbContext<NexQuestDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Default")));

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IQuestService, QuestService>();
        services.AddSingleton<NavigationService>();

        services.AddScoped<MainWindow>();
        services.AddScoped<Dashboard>();
        services.AddScoped<QuestList>();

        services.AddScoped<MainWindowViewModel>();
        services.AddScoped<DashboardViewModel>();
        services.AddScoped<QuestListViewModel>();
    }

    public static Dictionary<string, Type> PageMap { get; } = new() {
        { "Dashboard", typeof(Dashboard) },
        { "Quests", typeof(QuestList) },
    };


    public static Page? GetPageByName(string name)
    {
        if (AppHost?.Services is null || !PageMap.TryGetValue(name, out var type))
            return null;

        return AppHost.Services.GetService(type) as Page;
    }

}
