using ModernWpf.Controls;
using NexQuestGui.ViewModels;
using NexQuestGui.Views;
using System.Configuration;
using System.Windows;

namespace NexQuestGui
{
    public partial class MainWindow : Window
    {
        public MainWindow(MainWindowViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.SelectedItemContainer is NavigationViewItem selectedItem)
            {
                var tag = selectedItem.Tag?.ToString();

                switch (tag)
                {
                    case "Dashboard":
                        MainFrame.Navigate(new Dashboard());
                        break;
                    //case "Quests":
                    //    MainFrame.Navigate(new QuestsPage());
                    //    break;
                    //case "Settings":
                    //    MainFrame.Navigate(new SettingsPage());
                    //    break;
                }
            }
        }
    }
}