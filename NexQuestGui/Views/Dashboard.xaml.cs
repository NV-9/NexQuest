using NexQuestGui.ViewModels;
using System.Windows.Controls;

namespace NexQuestGui.Views;
public partial class Dashboard : Page
{
    public Dashboard(DashboardViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
