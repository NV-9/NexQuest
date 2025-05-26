using ModernWpf.Controls;
using System.Collections.ObjectModel;

namespace NexQuestGui.ViewModels;
public class MainWindowViewModel
{
    public ObservableCollection<NavigationItem> MenuItems { get; }

    public MainWindowViewModel()
    {
        MenuItems =
        [
            new NavigationItem { Content = "Dashboard", Tag = "Dashboard", Icon = Symbol.Home },
            
        ];
    }
}

public class NavigationItem
{
    public string Content { get; set; } = string.Empty;
    public string Tag { get; set; } = string.Empty;
    public Symbol Icon { get; set; }
}