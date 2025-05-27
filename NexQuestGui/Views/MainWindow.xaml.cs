using ModernWpf.Controls;
using NexQuestGui.ViewModels;
using System.Windows;

namespace NexQuestGui;
public partial class MainWindow : Window
{
    public MainWindow(MainWindowViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }

    private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
    {
        if (args?.SelectedItemContainer is not NavigationViewItem selectedItem)
            return;

        var tag = selectedItem.Tag?.ToString();
        if (string.IsNullOrEmpty(tag))
            return;
        
        var page = App.GetPageByName(tag);
        if (page is null)
            return;
        
        MainFrame.Navigate(page);
    }
}